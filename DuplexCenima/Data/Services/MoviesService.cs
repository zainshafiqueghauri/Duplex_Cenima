﻿using DuplexCenima.Data.Base;
using DuplexCenima.Data.ViewModel;
using DuplexCenima.Models;
using Microsoft.EntityFrameworkCore;

namespace DuplexCenima.Data.Services
{
    public class MoviesService:EntityBaseRepository<Movie>, iMoviesService
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            var newMovie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                CinemaId = data.CinemaId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                MovieCategory = data.MovieCategory,
                ProducerId = data.ProducerId
            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            //add Actors movie
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MoiveId = newMovie.Id,
                    ActorId = actorId,
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();  
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetail = await _context.Movies
                .Include(c => c.Cinema)
                .Include(p =>   p.Producers)
                .Include(am => am.Actors_Movies)
                .ThenInclude(a => a.Actors)
                .FirstOrDefaultAsync(n => n.Id == id);
            return movieDetail;
        }

        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownValues()
        {
            var response = new NewMovieDropdownsVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()

            };
            
            return response;
        }

        public async Task UpdateMovieAysnc(NewMovieVM data)
        {
            var dbMovie =  await _context.Movies.FirstOrDefaultAsync(n => n.Id ==  data.Id);
            if (dbMovie == null) 
            {
                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.Price = data.Price;
                dbMovie.ImageURL = data.ImageURL;
                dbMovie.CinemaId = data.CinemaId;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.MovieCategory = data.MovieCategory;
                dbMovie.ProducerId = data.ProducerId;
            
                await _context.SaveChangesAsync();
            }

            //remove existing actors
            var existingActorsDb = _context.Actors_Movies.Where(n => n.MoiveId == data.Id).ToList();
            _context.Actors_Movies.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync(); 

            //add Actors movie
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MoiveId = data.Id,
                    ActorId = actorId,
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }
    }
}

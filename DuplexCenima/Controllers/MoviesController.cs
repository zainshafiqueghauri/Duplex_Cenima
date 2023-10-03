using DuplexCenima.Data;
using DuplexCenima.Data.Services;
using DuplexCenima.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DuplexCenima.Controllers
{
    public class MoviesController : Controller
    {
        private readonly iMoviesService _service;
        public MoviesController(iMoviesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var MoviesData = await _service.GetAllAsync(n => n.Cinema);
            return View(MoviesData);
        }
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filtereResult = allMovies.Where(n => n.Name.Contains(searchString) || n.Description.Contains
                (searchString)).ToList();
                return View("Index", filtereResult);
            }

            return View("Index", allMovies);
        }

        //get/movie/detail
        public async Task<IActionResult> Details(int id)
        {
            var MovieDetail = await _service.GetMovieByIdAsync(id);
            return View(MovieDetail);
        }
        //get/ movie // create
        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetNewMovieDropdownValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if(!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMovieDropdownValues();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
                return View(movie);
            }
            await _service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));  
        }
        
        //get/ movie // Update 0r Edit
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetail = await _service.GetMovieByIdAsync(id);
            if (movieDetail == null) return View("NOT FOUND");

            var response = new NewMovieVM()
            {
                Id = movieDetail.Id,
                Name = movieDetail.Name,
                Description = movieDetail.Description,
                Price = movieDetail.Price,
                StartDate = movieDetail.StartDate,
                EndDate = movieDetail.EndDate,
                ImageURL = movieDetail.ImageURL,
                MovieCategory = movieDetail.MovieCategory,
                CinemaId = movieDetail.CinemaId,
                ProducerId = movieDetail.ProducerId,
                ActorIds = movieDetail.Actors_Movies.Select(n => n.ActorId).ToList(),
            };

            var movieDropdownsData = await _service.GetNewMovieDropdownValues();
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id) return View("NOT FOUND");
            
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMovieDropdownValues();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
                return View(movie);
            }
            await _service.UpdateMovieAysnc(movie);
            return RedirectToAction(nameof(Index));  
        }
    }
}

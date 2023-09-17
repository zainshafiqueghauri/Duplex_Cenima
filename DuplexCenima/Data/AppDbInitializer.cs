using DuplexCenima.Models;
using System.Runtime.InteropServices;

namespace DuplexCenima.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var ServiceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = ServiceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                    new Cinema()
                    {
                        Name = "Cinema 1",
                        Logo = "https://dotnethow.net/images/cinemas/cinema-1.jpeg",
                        Description = "This is the description of One movie"
                    },
                    new Cinema()
                    {
                        Name = "Cinema 2",
                        Logo = "https://dotnethow.net/images/cinemas/cinema-2.jpeg",
                        Description = "This is the description of 2nd movie"
                    },
                    new Cinema()
                    {
                        Name = "Cinema 3",
                        Logo = "https://dotnethow.net/images/cinemas/cinema-3.jpeg",
                        Description = "This is the description of 3rd movie"
                    },
                    new Cinema()
                    {
                        Name = "Cinema 4",
                        Logo = "https://dotnethow.net/images/cinemas/cinema-4.jpeg",
                        Description = "This is the description of 4th movie"
                    },
                    new Cinema()
                    {
                        Name = "Cinema 5",
                        Logo = "https://dotnethow.net/images/cinemas/cinema-5.jpeg",
                        Description = "This is the description of 5th movie"
                    },


                });
                    context.SaveChanges();
                }

                //actor 
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Actor 1",
                            Bio = "This is bio of 1st actor",
                            ProfilePictureURL = "https://dotnethow.net/images/actors/actor-1.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 2",
                            Bio = "This is bio of 2nd actor",
                            ProfilePictureURL = "https://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 3",
                            Bio = "This is bio of 3rd actor",
                            ProfilePictureURL = "https://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 4",
                            Bio = "This is bio of 4th actor",
                            ProfilePictureURL = "https://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 5",
                            Bio = "This is bio of 5th actor",
                            ProfilePictureURL = "https://dotnethow.net/images/actors/actor-5.jpeg"
                        },

                    });
                    context.SaveChanges();
                }

                //producer
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "producer 1",
                            Bio = "This is bio of 1st producer",
                            ProfilePictureURL = "https://dotnethow.net/images/producers/producer-1.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "producer 2",
                            Bio = "This is bio of 2nd producer",
                            ProfilePictureURL = "https://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "producer 3",
                            Bio = "This is bio of 3rd producer",
                            ProfilePictureURL = "https://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "producer 4",
                            Bio = "This is bio of 4th producer",
                            ProfilePictureURL = "https://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "producer 5",
                            Bio = "This is bio of 5th producer",
                            ProfilePictureURL = "https://dotnethow.net/images/producers/producer-5.jpeg"
                        },
                    });
                    context.SaveChanges();
                }

                //movie
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "The shawShank remdition",
                            Description = "The shawShank remdition full description",
                            Price = 39.50,
                            ImageURL = "https://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "No Country For Old Man",
                            Description = "No Country for Old Man",
                            Price = 39.50,
                            ImageURL = "https://dotnethow.net/images/movies/movie-2.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 4,
                            ProducerId = 4,
                            MovieCategory = MovieCategory.Comedy
                        },
                        new Movie()
                        {
                            Name = "Life",
                            Description = "Life full description",
                            Price = 39.50,
                            ImageURL = "https://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Figthing
                        },
                        new Movie()
                        {
                            Name = "Ghost",
                            Description = "ghost full description",
                            Price = 39.50,
                            ImageURL = "https://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Drama
                        },
                        new Movie()
                        {
                            Name = "Old Boy",
                            Description = "old Boy full description",
                            Price = 39.50,
                            ImageURL = "https://dotnethow.net/images/movies/movie-5.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            ProducerId = 5,
                            MovieCategory = MovieCategory.Action
                        },

                    });
                    context.SaveChanges();
                }

                //actor & movie
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MoiveId = 2
                        },
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MoiveId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MoiveId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MoiveId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MoiveId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MoiveId = 2
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MoiveId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MoiveId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MoiveId = 5
                        }
                    });
                    context.SaveChanges();

                }


            }
        }
    }
}

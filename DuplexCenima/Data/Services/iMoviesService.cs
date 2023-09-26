using DuplexCenima.Data.Base;
using DuplexCenima.Data.ViewModel;
using DuplexCenima.Models;

namespace DuplexCenima.Data.Services
{
    public interface iMoviesService:iEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownValues();
        Task AddNewMovieAsync(NewMovieVM data);
        Task UpdateMovieAysnc(NewMovieVM data);

    }
}

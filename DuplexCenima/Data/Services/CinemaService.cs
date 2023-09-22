using DuplexCenima.Data.Base;
using DuplexCenima.Models;

namespace DuplexCenima.Data.Services
{
    public class CinemaService:EntityBaseRepository<Cinema>, iCinemasService
    {
        public CinemaService(AppDbContext context) : base(context)
        {
            
        }
    }
}

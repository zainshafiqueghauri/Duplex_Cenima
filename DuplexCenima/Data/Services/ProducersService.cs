using DuplexCenima.Data.Base;
using DuplexCenima.Models;

namespace DuplexCenima.Data.Services
{
    public class ProducersService:EntityBaseRepository<Producer>, iProducersServices
    {
        public ProducersService(AppDbContext context): base(context)
        {
                
        }
    }
}

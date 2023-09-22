using DuplexCenima.Data.Base;
using DuplexCenima.Models;
using Microsoft.EntityFrameworkCore;

namespace DuplexCenima.Data.Services
{
    public class ActorService : EntityBaseRepository<Actor>, iActorServices
    {
        public ActorService(AppDbContext context) : base(context) { }
      
    }
}

using DuplexCenima.Models;
using Microsoft.EntityFrameworkCore;

namespace DuplexCenima.Data.Services
{
    public class ActorService : iActorServices
    {
        private readonly AppDbContext _context;
        public ActorService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task <IEnumerable<Actor>> GetAllAsync()
        {
            var result = await _context.Actors.ToListAsync();
            return result;
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            var result =await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public Actor Update(int id, Actor newActor)
        {
            throw new NotImplementedException();
        }
    }
}

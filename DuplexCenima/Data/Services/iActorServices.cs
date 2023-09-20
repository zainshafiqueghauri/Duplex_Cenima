using DuplexCenima.Models;

namespace DuplexCenima.Data.Services
{
    public interface iActorServices
    {
        Task <IEnumerable<Actor>> GetAllAsync();
        Task <Actor> GetByIdAsync(int id);
        Task AddAsync(Actor actor);
        Actor Update(int id, Actor newActor);
        void Delete(int id);

    }
}

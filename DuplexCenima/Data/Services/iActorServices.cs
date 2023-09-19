﻿using DuplexCenima.Models;

namespace DuplexCenima.Data.Services
{
    public interface iActorServices
    {
        Task <IEnumerable<Actor>> GetAll();
        Actor GetById(int id);
        void Add(Actor actor);
        Actor Update(int id, Actor newActor);
        void Delete(int id);

    }
}

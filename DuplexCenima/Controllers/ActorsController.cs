using DuplexCenima.Data;
using DuplexCenima.Data.Services;
using DuplexCenima.Models;
using Microsoft.AspNetCore.Mvc;

namespace DuplexCenima.Controllers
{
    public class ActorsController : Controller
    {
        private readonly iActorServices _service;

        public ActorsController(iActorServices service)
        {
            _service = service;
        }
        public async Task <IActionResult> Index()
        {
            var ActorData = await _service.GetAllAsync(); //taking data from the actor data through the App db context 
            return View(ActorData);
        }

        //get: actor create
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Actor actor) 
        {
            //if(!ModelState.IsValid)
            //{
            //    return View(actor);
            //}
            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //get:Actor detail
        public async Task<IActionResult> Details(int id)
        {
            //var ActorData = await _service.GetByIdAsync(id);
            //if (ActorData == null) return View("Empty");
            //return View(ActorData);

            var actorDetail = await _service.GetByIdAsync(id);

            if (actorDetail == null) return View("NOT FOUND");
            return View(actorDetail);
        }

        //get: actor> update fuction 
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetail = await _service.GetByIdAsync(id);
            if (actorDetail == null) return View("NOT FOUND");
            return View(actorDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Actor actor)
        {
            //if(!ModelState.IsValid)
            //{
            //    return View(actor);
            //}
            await _service.UpdateAsync(id,actor);
            return RedirectToAction(nameof(Index));
        }

        //get: Actor Delete Fuction

        public async Task<IActionResult> Delete(int id)
        {
            var actorDelete = await _service.GetByIdAsync(id);
            if (actorDelete == null) return View("NOT FOUND");
            return View(actorDelete);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDelete = await _service.GetByIdAsync(id);
            if (actorDelete == null) return View("NOT FOUND");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

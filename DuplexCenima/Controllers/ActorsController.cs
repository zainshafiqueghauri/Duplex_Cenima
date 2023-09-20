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

        //get actor create View from teh view>actor>create
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor) 
        {
            if(!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            //var ActorData = await _service.GetByIdAsync(id);
            //if (ActorData == null) return View("Empty");
            //return View(ActorData);

            var actorDetail = await _service.GetByIdAsync(id);

            if (actorDetail == null) return View("NOT FOUND");
            return View(actorDetail);
        }
    }
}

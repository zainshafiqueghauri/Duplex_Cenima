using DuplexCenima.Data;
using Microsoft.AspNetCore.Mvc;

namespace DuplexCenima.Controllers
{
    public class ActorsController : Controller
    {
        private readonly AppDbContext _context;

        public ActorsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var ActorData = _context.Actors.ToList(); //taking data from the actor data through the App db context 
            return View(ActorData);
        }
    }
}

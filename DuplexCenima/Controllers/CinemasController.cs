using DuplexCenima.Data;
using DuplexCenima.Data.Services;
using DuplexCenima.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DuplexCenima.Controllers
{
    public class CinemasController : Controller
    {
        private readonly iCinemasService _service;

        public CinemasController(iCinemasService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var CinemasData = await _service.GetAllAsync();
            return View(CinemasData);
        }

        //get/cinema/create
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cinema cinema)
        {
            await _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }
    }
}

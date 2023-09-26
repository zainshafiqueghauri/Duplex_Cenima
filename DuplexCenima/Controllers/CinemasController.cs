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

        //GET/CINEMA/DETAIL
        public async Task<IActionResult> Details(int id)
        {
            var ProducersDetails = await _service.GetByIdAsync(id);
            if (ProducersDetails == null) return View("NOT FOUND");
            return View(ProducersDetails);
        }

        //get/cinema/update or Edit

        public async Task<IActionResult> Edit(int id)
        {
            var ProducersDetails = await _service.GetByIdAsync(id);
            if (ProducersDetails == null) return View("NOT FOUND");
            return View(ProducersDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Cinema cinema)
        {
            await _service.UpdateAsync(id, cinema);
            return RedirectToAction(nameof(Index));
        }

        //get/Cinema/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var ProducerDetail = await _service.GetByIdAsync(id);
            if (ProducerDetail == null) return View("NotFound");
            return View(ProducerDetail);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ProducerDetail = await _service.GetByIdAsync(id);
            if (ProducerDetail == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}

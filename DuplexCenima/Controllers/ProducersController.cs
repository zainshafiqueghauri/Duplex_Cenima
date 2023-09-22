using DuplexCenima.Data;
using DuplexCenima.Data.Services;
using DuplexCenima.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DuplexCenima.Controllers
{
    public class ProducersController : Controller
    {
        private readonly iProducersServices _serviece;
        public ProducersController(iProducersServices service)
        {
            _serviece = service;
        }
        public async Task<IActionResult> Index()
        {
            var ProducerData = await _serviece.GetAllAsync();
            return View(ProducerData);
        }

        //get /producer/details/by id
        public async Task<IActionResult> Details(int id)
        {
            var ProducersDetails = await _serviece.GetByIdAsync(id);
            if( ProducersDetails == null ) return View("NotFound");
            return View( ProducersDetails);
        }

        //get/producer/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Producer producer)
        {
            await _serviece.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        //get/producer/Update or Edit
        public async Task<IActionResult> Edit(int id)
        {
            var ProducerDetail = await _serviece.GetByIdAsync(id);
            if( ProducerDetail == null ) return View("NotFound");
            return View(ProducerDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Producer producer)
        {
            if(id == producer.Id)
            {
                await _serviece.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }

        //get/producer/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var ProducerDetail = await _serviece.GetByIdAsync(id);
            if (ProducerDetail == null) return View("NotFound");
            return View(ProducerDetail);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ProducerDetail = await _serviece.GetByIdAsync(id);
            if (ProducerDetail == null) return View("NotFound");

            await _serviece.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

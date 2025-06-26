using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;
using TodoApp.Services;

namespace TodoApp.Controllers
{
public class HomeController : Controller
    {
        private readonly Iservices service;

        public HomeController(Iservices service)
        {
            this.service = service;
        }

       
        public async Task<IActionResult> Index()
        {
            var items = await service.GetAll();
            return View(items);
        }
          public IActionResult Privacy()
    {
        return View();
    }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(TodoItems item)
        {
            if (ModelState.IsValid)
            {
                await service.Add(item);
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

       
        public async Task<IActionResult> Edit(int id)
        {
            var item = await service.GetById(id);
            if (item == null) return NotFound();
            return View(item);
        }

    
        [HttpPost]
        public async Task<IActionResult> Edit(TodoItems item)
        {
            if (ModelState.IsValid)
            {
                await service.Update(item);
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        
        public async Task<IActionResult> Delete(int id)
        {
            await service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

       
        public async Task<IActionResult> DeleteAll()
        {
            await service.DeleteAll();
            return RedirectToAction(nameof(Index));
        }
    }
}
using Business.Services;
using Business.ViewModels;
using Business.ViewModels.Type;
using Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Pokedex.Controllers
{
    public class TypeController : Controller
    {
        private readonly TypeService _typeService;
        private readonly EntitiesService _entitiesService;

        public TypeController(ApplicationContext DbContext)
        {
            _typeService = new(DbContext);
            _entitiesService = new EntitiesService(DbContext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _entitiesService.GetEntitiesViewModel());
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _typeService.GetTypeById(id));
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _typeService.GetTypeById(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _typeService.Delete(id);
            return RedirectToRoute(new { controller = "Type", action = "Index" });
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveTypeViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);
            await _typeService.Add(vm);
            return RedirectToRoute(new { controller = "Type", action = "Index" });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveTypeViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);
            await _typeService.Update(vm);
            return RedirectToRoute(new { controller = "Type", action = "Index" });
        }
    }
}

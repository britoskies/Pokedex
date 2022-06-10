using Business.Services;
using Business.ViewModels;
using Business.ViewModels.Region;
using Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Pokedex.Controllers
{
    public class RegionController : Controller
    {
        private readonly RegionService _regionService;
        private readonly EntitiesService _entitiesService;

        public RegionController(ApplicationContext DbContext)
        {
            _regionService = new(DbContext);
            _entitiesService = new(DbContext);
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
            return View(await _regionService.GetRegionById(id));
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _regionService.GetRegionById(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _regionService.Delete(id);
            return RedirectToRoute(new { controller = "Region", action = "Index" });
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveRegionViewModel vm)
        {
            if(!ModelState.IsValid) return View(vm);
            await _regionService.Add(vm);
            return RedirectToRoute(new { controller = "Region", action = "Index" });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveRegionViewModel vm)
        {
            if (!ModelState.IsValid) return View(await _regionService.GetRegionById(vm.Id));
            await _regionService.Update(vm);
            return RedirectToRoute(new { controller = "Region", action = "Index" });
        }
    }
}

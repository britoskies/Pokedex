using Business.Services;
using Business.ViewModels;
using Business.ViewModels.Pokemon;
using Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Pokedex.Controllers
{
    public class PokemonController : Controller
    {
        private readonly PokemonService _pokemonService;
        private readonly RegionService _regionService;
        private readonly TypeService _typeService;
        private readonly EntitiesService _entitiesService;

        public PokemonController(ApplicationContext DbContext)
        {
            _pokemonService = new PokemonService(DbContext);
            _regionService = new RegionService(DbContext);
            _typeService = new TypeService(DbContext);
            _entitiesService = new EntitiesService(DbContext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _entitiesService.GetEntitiesViewModel());
        }

        public async Task<IActionResult> Create()
        {
            return View(new SavePokemonViewModel()
            {
                RegionList = await _regionService.GetAllViewModel(),
                TypeList = await _typeService.GetAllViewModel()
            });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var pokemonvm = await _pokemonService.GetPokemonById(id);

            SavePokemonViewModel vm = new()
            {
                Id = pokemonvm.Id,
                Name = pokemonvm.Name,
                ImageURL = pokemonvm.ImageURL,
                RegionId = pokemonvm.RegionId,
                TypePrimaryId = pokemonvm.TypePrimaryId,
                TypeSecondaryId = pokemonvm.TypeSecondaryId,
                RegionList = await _regionService.GetAllViewModel(),
                TypeList = await _typeService.GetAllViewModel()
            };

            return View(vm);
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _pokemonService.GetPokemonById(id));
        }



        // ALL POSTS

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _pokemonService.Delete(id);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }

        [HttpPost]
        public async Task<IActionResult> Create(SavePokemonViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.RegionList = await _regionService.GetAllViewModel();
                vm.TypeList = await _typeService.GetAllViewModel();
                return View(vm);
            }

            await _pokemonService.Add(vm);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SavePokemonViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.RegionList = await _regionService.GetAllViewModel();
                vm.TypeList = await _typeService.GetAllViewModel();
                return View(vm);
            }

            await _pokemonService.Update(vm);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }
    }
}

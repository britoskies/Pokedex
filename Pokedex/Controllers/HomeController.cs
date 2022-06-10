using Business.Services;
using Business.ViewModels;
using Business.ViewModels.Management;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Controllers
{
    public class HomeController : Controller
    {
        private readonly RegionService _regionService;
        private readonly PokemonService _pokemonService;

        public HomeController(ApplicationContext DbContext)
        {
            _pokemonService = new PokemonService(DbContext);
            _regionService = new RegionService(DbContext);
        }

        public async Task<IActionResult> Index(FilteringViewModel vm)
        {
            ViewBag.Regions = await _regionService.GetAllViewModel();
            return View(await _pokemonService.GetAllWithFilters(vm));
        }
    }
}

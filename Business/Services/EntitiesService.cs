using Business.Repository;
using Business.ViewModels;
using Business.ViewModels.Management;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class EntitiesService
    {
        private readonly PokemonService _pokemonService;
        private readonly RegionService _regionService;
        private readonly TypeService _typeService;

        public EntitiesService(ApplicationContext DbContext)
        {
            _pokemonService = new PokemonService(DbContext);
            _regionService = new RegionService(DbContext);
            _typeService = new TypeService(DbContext);
        }

        public async Task<EntitiesViewModel> GetEntitiesViewModel()
        {
            return new EntitiesViewModel()
            {
                PokemonList = await _pokemonService.GetAllViewModel(),
                RegionList = await _regionService.GetAllViewModel(),
                TypeList = await _typeService.GetAllViewModel()
            };
        }
    }
}

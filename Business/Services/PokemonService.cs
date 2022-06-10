using Business.Repository;
using Business.ViewModels;
using Business.ViewModels.Management;
using Business.ViewModels.Pokemon;
using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class PokemonService
    {
        private readonly PokemonRepo _pokemonRepo;

        public PokemonService(ApplicationContext DbContext)
        {
            _pokemonRepo = new PokemonRepo(DbContext);
        }

        public async Task Delete(int id)
        {
            var pokemon = await _pokemonRepo.GetByIdAsync(id);
            await _pokemonRepo.DeleteAsync(pokemon);
        }

        public async Task Update(SavePokemonViewModel vm)
        {
            PokemonModel pokemon = new();
            pokemon.Id = vm.Id;
            pokemon.Name = vm.Name;
            pokemon.ImageURL = vm.ImageURL;
            pokemon.RegionId = vm.RegionId;
            pokemon.TypePrimaryId = vm.TypePrimaryId;
            pokemon.TypeSecondaryId = vm.TypeSecondaryId;

            await _pokemonRepo.UpdateAsync(pokemon);
        }

        public async Task Add(SavePokemonViewModel vm)
        {
            PokemonModel pokemon = new();
            pokemon.Name = vm.Name;
            pokemon.ImageURL = vm.ImageURL;
            pokemon.RegionId = vm.RegionId;
            pokemon.TypePrimaryId = vm.TypePrimaryId;
            pokemon.TypeSecondaryId = vm.TypeSecondaryId;

            await _pokemonRepo.AddAsync(pokemon);
        }

        public async Task<SavePokemonViewModel> GetPokemonById(int id)
        {
            var pokemon = await _pokemonRepo.GetByIdAsync(id);

            SavePokemonViewModel vm = new()
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                ImageURL = pokemon.ImageURL,
                RegionId = pokemon.RegionId,
                TypePrimaryId = pokemon.TypePrimaryId,
                TypeSecondaryId = pokemon.TypeSecondaryId
            };

            return vm;
        }

        public async Task<List<PokemonViewModel>> GetAllViewModel()
        {
            var pokemonList = await _pokemonRepo.GetAllAsync();
            return pokemonList.Select(pokemon => new PokemonViewModel
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                ImageURL = pokemon.ImageURL,
                Region = pokemon.Region.Name,
                TypePrimary = pokemon.TypePrimary.Name,
                TypeSecondary = pokemon.TypeSecondary.Name,
                RegionId = pokemon.Region.Id

            }).ToList();
        }

        public async Task<List<PokemonViewModel>> GetAllWithFilters(FilteringViewModel filter)
        {
            var pokemonList = await _pokemonRepo.GetAllAsync();
            var viewModelList = pokemonList.Select(pokemon => new PokemonViewModel
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                ImageURL = pokemon.ImageURL,
                Region = pokemon.Region.Name,
                TypePrimary = pokemon.TypePrimary.Name,
                TypeSecondary = pokemon.TypeSecondary.Name,
                RegionId = pokemon.Region.Id,

            }).ToList();

            if (filter.RegionId != null)
            {
                viewModelList = viewModelList
                    .Where(pokemon => pokemon.RegionId == filter.RegionId.Value)
                    .ToList();
            }

            if (!String.IsNullOrEmpty(filter.PokemonName))
            {
                viewModelList = viewModelList
                    .Where(pokemon => pokemon.Name.Contains(filter.PokemonName))
                    .ToList();
            }

            return viewModelList;
        }
    }
}

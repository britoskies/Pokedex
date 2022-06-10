using Business.Repository;
using Business.ViewModels;
using Business.ViewModels.Type;
using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class TypeService
    {
        private readonly TypeRepo _typeRepo;
        private readonly PokemonRepo _pokemonRepo;
        public TypeService(ApplicationContext DbContext)
        {
            _typeRepo = new TypeRepo(DbContext);
            _pokemonRepo = new PokemonRepo(DbContext);
        }

        public async Task Delete(int id)
        {
            var type = await _typeRepo.GetByIdAsync(id);
            var pokemonList = await _pokemonRepo.GetAllAsync();

            foreach (var item in pokemonList)
            {
                // Asigning default type secondary to avoid sending nulls to DB
                if (item.TypeSecondaryId == id) item.TypeSecondaryId = 5;
            }

            await _typeRepo.DeleteAsync(type);
        }

        public async Task Update(SaveTypeViewModel vm)
        {
            TypeModel type = new();
            type.Id = vm.Id;
            type.Name = vm.Name;

            await _typeRepo.UpdateAsync(type);
        }

        public async Task Add(SaveTypeViewModel vm)
        {
            TypeModel type = new();
            type.Id = vm.Id;
            type.Name = vm.Name;

            await _typeRepo.AddAsync(type);
        }

        public async Task<SaveTypeViewModel> GetTypeById(int id)
        {
            var type = await _typeRepo.GetByIdAsync(id);

            SaveTypeViewModel vm = new()
            {
                Id = type.Id,
                Name = type.Name,
            };

            return vm;
        }

        public async Task<List<TypeViewModel>> GetAllViewModel()
        {
            var typeList = await _typeRepo.GetAllAsync();
            return typeList.Select(type => new TypeViewModel
            {
                Id = type.Id,
                Name = type.Name,

            }).ToList();
        }
    }
}

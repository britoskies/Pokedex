using Business.Repository;
using Business.ViewModels;
using Business.ViewModels.Region;
using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class RegionService
    {
        private readonly RegionRepo _regionRepo;
        public RegionService(ApplicationContext DbContext)
        {
            _regionRepo = new RegionRepo(DbContext);
        }

        public async Task Delete(int id)
        {
            var region = await _regionRepo.GetByIdAsync(id);
            await _regionRepo.DeleteAsync(region);
        }

        public async Task Update(SaveRegionViewModel vm)
        {
            RegionModel region = new();
            region.Id = vm.Id;
            region.Name = vm.Name;

            await _regionRepo.UpdateAsync(region);
        }

        public async Task Add(SaveRegionViewModel vm)
        {
            RegionModel region = new();
            region.Id = vm.Id;
            region.Name = vm.Name;

            await _regionRepo.AddAsync(region);
        }

        public async Task<SaveRegionViewModel> GetRegionById(int id)
        {
            var region = await _regionRepo.GetByIdAsync(id);

            SaveRegionViewModel vm = new()
            {
                Id = region.Id,
                Name = region.Name,
            };

            return vm;
        }

        public async Task<List<RegionViewModel>> GetAllViewModel()
        {
            var regionList = await _regionRepo.GetAllAsync();
            return regionList.Select(region => new RegionViewModel
            {
                Id = region.Id,
                Name = region.Name,

            }).ToList();
        }
    }
}

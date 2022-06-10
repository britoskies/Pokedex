using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class RegionRepo
    {
        private readonly ApplicationContext DbContext;

        public RegionRepo(ApplicationContext AppDbContext)
        {
            DbContext = AppDbContext;
        }

        public async Task AddAsync(RegionModel region)
        {
            await DbContext.Regions.AddAsync(region);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(RegionModel region)
        {
            DbContext.Entry(region).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(RegionModel region)
        {
            DbContext.Set<RegionModel>().Remove(region);
            await DbContext.SaveChangesAsync();
        }

        public async Task<List<RegionModel>> GetAllAsync()
        {
            return await DbContext.Set<RegionModel>().ToListAsync();
        }

        public async Task<RegionModel> GetByIdAsync(int id)
        {
            return await DbContext.Set<RegionModel>().FindAsync(id);
        }
    }
}

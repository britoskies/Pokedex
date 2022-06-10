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
    public class TypeRepo
    {
        private readonly ApplicationContext DbContext;

        public TypeRepo(ApplicationContext AppDbContext)
        {
            DbContext = AppDbContext;
        }

        public async Task AddAsync(TypeModel type)
        {
            await DbContext.Types.AddAsync(type);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TypeModel type)
        {
            DbContext.Entry(type).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TypeModel type)
        {
            DbContext.Set<TypeModel>().Remove(type);
            await DbContext.SaveChangesAsync();
        }

        public async Task<List<TypeModel>> GetAllAsync()
        {
            return await DbContext.Set<TypeModel>().ToListAsync();
        }

        public async Task<TypeModel> GetByIdAsync(int id)
        {
            return await DbContext.Set<TypeModel>().FindAsync(id);
        }
    }
}

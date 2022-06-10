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
    public class PokemonRepo
    {
        private readonly ApplicationContext DbContext;

        public PokemonRepo(ApplicationContext AppDbContext)
        {
            DbContext = AppDbContext;
        }

        public async Task AddAsync(PokemonModel pokemon)
        {
            await DbContext.Pokemons.AddAsync(pokemon);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(PokemonModel pokemon)
        {
            DbContext.Entry(pokemon).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(PokemonModel pokemon)
        {
            DbContext.Set<PokemonModel>().Remove(pokemon);
            await DbContext.SaveChangesAsync();
        }

        public async Task<List<PokemonModel>> GetAllAsync()
        {
            return await DbContext.Set<PokemonModel>()
                .Include(pokemon => pokemon.Region)
                .Include(pokemon => pokemon.TypePrimary)
                .Include(pokemon => pokemon.TypeSecondary)
                .ToListAsync();
        }

        public async Task<PokemonModel> GetByIdAsync(int id)
        {
            return await DbContext.Set<PokemonModel>()
                .Include(pokemon => pokemon.Region)
                .Include(pokemon => pokemon.TypePrimary)
                .Include(pokemon => pokemon.TypeSecondary)
                .FirstOrDefaultAsync(pokemon => pokemon.Id == id);
        }
    }
}

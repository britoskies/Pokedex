using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<PokemonModel> Pokemons { get; set; }
        public DbSet<RegionModel> Regions { get; set; }
        public DbSet<TypeModel> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API

            #region tables
            modelBuilder.Entity<PokemonModel>().ToTable("Pokemons");
            modelBuilder.Entity<RegionModel>().ToTable("Regions");
            modelBuilder.Entity<TypeModel>().ToTable("Types");
            #endregion

            #region primary keys
            modelBuilder.Entity<PokemonModel>().HasKey(pokemon => pokemon.Id);
            modelBuilder.Entity<RegionModel>().HasKey(region => region.Id);
            modelBuilder.Entity<TypeModel>().HasKey(type => type.Id);
            #endregion

            #region relationships
            modelBuilder.Entity<RegionModel>()
                .HasMany(region => region.Pokemons)
                .WithOne(pokemon => pokemon.Region)
                .HasForeignKey(pokemon => pokemon.RegionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TypeModel>()
                .HasMany(type => type.TypePrimary)
                .WithOne(pokemon => pokemon.TypePrimary)
                .HasForeignKey(pokemon => pokemon.TypePrimaryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TypeModel>()
                .HasMany(type => type.TypeSecondary)
                .WithOne(pokemon => pokemon.TypeSecondary)
                .HasForeignKey(pokemon => pokemon.TypeSecondaryId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region property configs

            #region pokemons
            modelBuilder.Entity<PokemonModel>()
                .Property(pokemon => pokemon.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<PokemonModel>()
                .Property(pokemon => pokemon.ImageURL)
                .IsRequired();

            modelBuilder.Entity<PokemonModel>()
                .Property(pokemon => pokemon.RegionId)
                .IsRequired();

            modelBuilder.Entity<PokemonModel>()
                .Property(pokemon => pokemon.TypePrimaryId)
                .IsRequired();

            modelBuilder.Entity<PokemonModel>()
                .Property(pokemon => pokemon.TypeSecondaryId)
                .IsRequired();
            #endregion

            #region regions
            modelBuilder.Entity<RegionModel>()
                .Property(region => region.Name)
                .IsRequired();
            #endregion

            #region types
            modelBuilder.Entity<TypeModel>()
                .Property(type => type.Name)
                .IsRequired();
            #endregion  

            #endregion
        }
    }
}

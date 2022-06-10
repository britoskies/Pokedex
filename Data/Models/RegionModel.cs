using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class RegionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation Prop
        public ICollection<PokemonModel> Pokemons { get; set; }
    }
}

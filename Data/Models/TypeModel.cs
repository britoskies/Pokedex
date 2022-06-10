using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class TypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation Prop
        public ICollection<PokemonModel> TypePrimary { get; set; }
        public ICollection<PokemonModel> TypeSecondary { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class PokemonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }

        // Region References
        public int RegionId { get; set; }
        public RegionModel Region { get; set; }

        // Type References
        public int TypePrimaryId { get; set; }
        public TypeModel TypePrimary { get; set; }

        public int TypeSecondaryId { get; set; }
        public TypeModel TypeSecondary { get; set; }
    }
}

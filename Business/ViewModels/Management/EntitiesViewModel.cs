using Business.ViewModels.Pokemon;
using Business.ViewModels.Region;
using Business.ViewModels.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels.Management
{
    public class EntitiesViewModel
    {
        public List<PokemonViewModel> PokemonList { get; set; }
        public List<RegionViewModel> RegionList { get; set; }
        public List<TypeViewModel> TypeList { get; set; }
    }
}

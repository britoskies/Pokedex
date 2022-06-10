using Business.ViewModels.Region;
using Business.ViewModels.Type;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels.Pokemon
{
    public class SavePokemonViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El campo nombre es requerido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La URL de la imágen es requerido")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "El campo región es requerido")]
        public int RegionId { get; set; }

        [Required(ErrorMessage = "El campo de tipo primario es requerido")]
        public int TypePrimaryId { get; set; }
        public int TypeSecondaryId { get; set; }

        public List<RegionViewModel> RegionList { get; set; }

        public List<TypeViewModel> TypeList { get; set; }
    }
}

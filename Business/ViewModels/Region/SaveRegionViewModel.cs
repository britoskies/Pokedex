using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels.Region
{
    public class SaveRegionViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Porfavor, llene el campo nombre")]
        public string Name { get; set; }
    }
}

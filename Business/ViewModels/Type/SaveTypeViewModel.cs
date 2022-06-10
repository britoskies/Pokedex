using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels.Type
{
    public class SaveTypeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Porfavor, llene el campo nombre")]
        public string Name { get; set; }
    }
}

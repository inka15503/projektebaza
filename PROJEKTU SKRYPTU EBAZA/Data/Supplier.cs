using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PROJEKTU_SKRYPTU_EBAZA.Data
{
    public class Supplier
    {
        public int Id { get; set; }

        //W formularzu wyświetl tytuł "Nazwa firmy"
        [Display(Name = "Nazwa Firmy")]

        //Parametr wymagany, minimum 3 znaki
        [Required(ErrorMessage ="Nazwa jest wymagana")]        
        [MinLength(3, ErrorMessage = "Minimalna długość to 3 znaki")]
        public string Name { get; set; }

        //Parametr wymagany, minimum 3 znaki
        [Required(ErrorMessage = "NIP jest wymagany")]
        [MinLength(3, ErrorMessage = "Minimalna długość to 3 znaki")]
        public string NIP { get; set; }

        public string Regon { get; set; }
        public string KRS { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}

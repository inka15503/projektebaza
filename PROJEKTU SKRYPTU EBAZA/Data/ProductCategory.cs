using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PROJEKTU_SKRYPTU_EBAZA.Data
{
    public class ProductCategory
    {
        public int Id { get; set; }

        //W formularzu wyświetl tytuł "Nazwa Kategorii"
        [Display(Name ="Nazwa Kategorii")]
        //Parametr wymagany, musi posiadać min 3 znaki
        [Required(ErrorMessage ="Nazwa jest wymagana")]
        [MinLength(3,ErrorMessage = "Minimalna długość to 3 znaki")]
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
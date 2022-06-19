using System.ComponentModel.DataAnnotations;

namespace PROJEKTU_SKRYPTU_EBAZA.Data
{
    public class Product
    {
        public int Id { get; set; }
        //Paramets wymagany o minimalnej liczbie znaków 3
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [MinLength(3, ErrorMessage = "Minimalna długość to 3 znaki")]

        //W formularzu wyświetl tytuł "Nazwa produktu"
        [Display(Name = "Nazwa Produktu")]
        public string Name { get; set; }
        public string EAN { get; set; }
        public string ImgPath { get; set; }


        //W formularzu wyświetl tytuł "Cena"
        [Display(Name="Cena")]
        public float Price { get; set; }

        //W formularzu wyświetl tytuł "Cena po przecenie (niewymagane)"
        [Display(Name = "Cena po przecenie (niewymagane)")]

        // ?- Parametr może być nullem
        public float? Discount { get; set; }

        // ?- Parametr może być nullem
        public int? CategoryId { get; set; }
       
        public ProductCategory Category { get; set; }

        // ?- Parametr może być nullem
        public int? SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
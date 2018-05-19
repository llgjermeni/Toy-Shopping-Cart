using System.ComponentModel.DataAnnotations;

namespace ToyApp.Data.Data
{
    public class Toy
    {
        public int ToyID { get; set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string ToyName { get; set; }

        [Required, StringLength(10000), Display(Name = "Toy Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public double UnitPrice { get; set; }

        public int? CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}

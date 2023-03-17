using System.ComponentModel.DataAnnotations;

namespace testASP.Models.ViewModels
{
    public class BeerViewModel
    {
        [Required]
        [Display(Name="Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public int BrandId { get; set; }
    }
}

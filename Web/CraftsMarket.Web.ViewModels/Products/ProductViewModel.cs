namespace CraftsMarket.Web.ViewModels.Products
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using CraftsMarket.Data.Models;
    using CraftsMarket.Services.Mapping;

    public class ProductViewModel : IMapTo<Product>, IMapFrom<Product>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(0.01, 100000)]
        public decimal Price { get; set; }

        [Range(0.01, 1000)]
        [Display(Name = "Quantity")]
        public int InStock { get; set; }

        [Required]
        [MinLength(20)]
        public string Description { get; set; }

        public string CategoryName { get; set; }

        public ICollection<string> ImageUrls { get; set; }
    }
}

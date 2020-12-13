using System.Collections.Generic;

namespace CraftsMarket.Web.ViewModels.Products
{
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

        public decimal Price { get; set; }

        public int InStock { get; set; }

        public string Description { get; set; }

        public ICollection<string> ImageUrls { get; set; }
    }
}

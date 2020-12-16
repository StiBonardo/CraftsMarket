namespace CraftsMarket.Web.ViewModels.Products
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using CraftsMarket.Data.Models;
    using CraftsMarket.Services.Mapping;

    public class CreateProductInputModel : IMapTo<Product>
    {
        //[Required]
        //[MinLength(3)]
        //[MaxLength(50)]
        public string Name { get; set; }

        //[Required]
        //[Range(0.01, 100000)]
        public decimal Price { get; set; }

        //[Range(0, 1000)]
        [Display(Name = "Quantity")]
        public int InStock { get; set; }

        //[Required]
        //[MinLength(20)]
        public string Description { get; set; }

        public string UserId { get; set; }

        public string CategoryName { get; set; }

        [Display(Name = "Category")]
        public IEnumerable<SelectListItem> Categories { get; set; }

        ////public ICollection<string> ImageUrls { get; set; }
    }
}

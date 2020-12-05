using System.ComponentModel.DataAnnotations;

namespace CraftsMarket.Data.Models
{
    using System.Collections.Generic;

    using CraftsMarket.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

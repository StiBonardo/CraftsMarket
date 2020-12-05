using System.ComponentModel.DataAnnotations;

namespace CraftsMarket.Data.Models
{
    using System.Collections.Generic;

    using CraftsMarket.Data.Common.Models;

    public class Tag : BaseDeletableModel<int>
    {
        public Tag()
        {
            this.ProductTags = new HashSet<ProductTag>();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int ProductId { get; set; }

        public virtual ICollection<ProductTag> ProductTags { get; set; }
    }
}

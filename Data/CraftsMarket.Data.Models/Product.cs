﻿using Microsoft.AspNetCore.Identity;

namespace CraftsMarket.Data.Models
{
    using System.Collections.Generic;
    using System.Net.Mime;

    using CraftsMarket.Data.Common.Models;

    public class Product : BaseDeletableModel<int>
    {
        public Product()
        {
            this.Comments = new HashSet<Comment>();
            this.Images = new HashSet<Image>();
            this.ProductTags = new HashSet<ProductTag>();
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int InStock { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<ProductTag> ProductTags { get; set; }
    }
}
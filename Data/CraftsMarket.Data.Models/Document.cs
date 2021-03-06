﻿namespace CraftsMarket.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using CraftsMarket.Data.Common.Models;

    public class Document : BaseDeletableModel<string>
    {
        public Document()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Path { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}

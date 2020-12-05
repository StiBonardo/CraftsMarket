using System.ComponentModel.DataAnnotations;

namespace CraftsMarket.Data.Models
{
    using System.Collections.Generic;

    using CraftsMarket.Data.Common.Models;
    using Microsoft.AspNetCore.Identity;

    public class Town : BaseDeletableModel<int>
    {
        public Town()
        {
            this.Users = new HashSet<ApplicationUser>();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}

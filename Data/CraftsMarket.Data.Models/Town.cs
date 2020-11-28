namespace CraftsMarket.Data.Models
{
    using System.Collections.Generic;

    using CraftsMarket.Data.Common.Models;
    using Microsoft.AspNetCore.Identity;

    public class Town : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        ////public ICollection<IdentityUser> Users { get; set; }
    }
}

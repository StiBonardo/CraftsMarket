namespace CraftsMarket.Data.Models
{
    using System;

    using CraftsMarket.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class Document : BaseDeletableModel<string>
    {
        public Document()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Name { get; set; }

        public string Path { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}

// ReSharper disable VirtualMemberCallInConstructor

using System.ComponentModel.DataAnnotations;

namespace CraftsMarket.Data.Models
{
    using System;

    using CraftsMarket.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationRole : IdentityRole, IAuditInfo, IDeletableEntity
    {
        public ApplicationRole()
            : this(null)
        {
        }

        public ApplicationRole(string name)
            : base(name)
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(50)]
        public override string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string Description { get; set; }
    }
}

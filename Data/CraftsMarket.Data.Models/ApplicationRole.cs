﻿// ReSharper disable VirtualMemberCallInConstructor

namespace CraftsMarket.Data.Models
{
    using System;
    using System.Collections.Generic;

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

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string Description { get; set; }
    }
}

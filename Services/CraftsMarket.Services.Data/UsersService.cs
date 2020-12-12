namespace CraftsMarket.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CraftsMarket.Common;
    using CraftsMarket.Data.Common.Repositories;
    using CraftsMarket.Data.Models;
    using Microsoft.AspNetCore.Identity;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IDeletableEntityRepository<ApplicationRole> roleRepository;

        public UsersService(
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IDeletableEntityRepository<ApplicationRole> roleRepository)
        {
            this.usersRepository = usersRepository;
            this.roleRepository = roleRepository;
        }
    }
}

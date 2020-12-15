namespace CraftsMarket.Web.Controllers
{
    using CraftsMarket.Common;
    using CraftsMarket.Services.Data;

    using Microsoft.AspNetCore.Authorization;

    public class UsersController : BaseController
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;

            ////if (this.User.Identity.Name == GlobalConstants.OwnerUsername)
            ////{
            ////   //// var user = this.usersService.
            ////}
        }
    }
}

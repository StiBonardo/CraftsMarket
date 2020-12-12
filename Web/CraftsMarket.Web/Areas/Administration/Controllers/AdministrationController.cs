namespace CraftsMarket.Web.Areas.Administration.Controllers
{
    using CraftsMarket.Common;
    using CraftsMarket.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}

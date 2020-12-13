namespace CraftsMarket.Web.Areas.Administration.Controllers
{
    using CraftsMarket.Web.ViewModels.Products;

    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : AdministrationController
    {
        public DashboardController()
        {
        }

        public IActionResult Index()
        {
            return this.View();
        }
    }
}

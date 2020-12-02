using Microsoft.AspNetCore.Mvc;

namespace CraftsMarket.Web.Controllers
{
    public class ProductsController : BaseController
    {
        public IActionResult All()
        {
            return this.View();
        }
    }
}

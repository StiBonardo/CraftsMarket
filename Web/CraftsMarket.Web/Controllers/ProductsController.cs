namespace CraftsMarket.Web.Controllers
{
    using CraftsMarket.Services.Data;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : BaseController
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public IActionResult All()
        {
            return this.View();
        }
    }
}

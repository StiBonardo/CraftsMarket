namespace CraftsMarket.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using CraftsMarket.Data.Models;
    using CraftsMarket.Services.Data;
    using CraftsMarket.Web.ViewModels.Products;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : BaseController
    {
        private readonly IProductsService productsService;
        private readonly UserManager<ApplicationUser> userManager;

        public ProductsController(
            IProductsService productsService,
            UserManager<ApplicationUser> userManager)
        {
            this.productsService = productsService;
            this.userManager = userManager;
        }

        public IActionResult Index(int productId)
        {
            var viewModel = this.productsService.GetById(productId);
            return this.View(viewModel);
        }

        [Route("/Products")]
        public IActionResult All()
        {
            var productsViewModel = new ListOfProductsViewModel();
            if (this.User.Identity.IsAuthenticated)
            {
                productsViewModel.MyProducts = this.productsService.AllForUser(this.User.Identity.Name).ToList();
            }

            productsViewModel.AllProducts = this.productsService.All().ToList();

            return this.View(productsViewModel);
        }

        public IActionResult Add()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            return this.View();
        }

        public IActionResult AllFromCategory(string category)
        {
            var viewModel = new AllFromCategoryViewModel
            {
                Products = this.productsService.AllFromCategory(category).ToList(),
            };

            return this.View(viewModel);
        }
    }
}

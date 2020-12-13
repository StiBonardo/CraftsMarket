using System.Collections.Generic;
using System.Linq;
using CraftsMarket.Data.Models;
using CraftsMarket.Web.ViewModels.Products;
using Microsoft.AspNetCore.Identity;

namespace CraftsMarket.Web.Controllers
{
    using CraftsMarket.Services.Data;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : BaseController
    {
        private readonly IProductsService productsService;
        private readonly UserManager<ApplicationUser> userManager;

        public ProductsController(IProductsService productsService, UserManager<ApplicationUser> userManager)
        {
            this.productsService = productsService;
            this.userManager = userManager;
        }

        public IActionResult Index(int productId)
        {
            var viewModel = this.productsService.ById(productId);
            return this.View(viewModel);
        }

        public IActionResult All()
        {
            var productsViewModel = new ListOfProductsViewModel();
            if (this.User.Identity.IsAuthenticated)
            {
                var userId = this.userManager.GetUserId(this.User);
                productsViewModel.MyProducts = this.productsService.AllForUser(userId).ToList();
            }

            productsViewModel.AllProducts = this.productsService.All().ToList();

            return this.View(productsViewModel);
        }

        public IActionResult Add()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                this.Redirect("/Identity/Account/Login");
            }

            return this.View();
        }

    }
}

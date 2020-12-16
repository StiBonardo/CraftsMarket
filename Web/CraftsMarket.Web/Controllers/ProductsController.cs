using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;

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
        private readonly ICategoriesService categoriesService;

        public ProductsController(
            IProductsService productsService,
            UserManager<ApplicationUser> userManager,
            ICategoriesService categoriesService)
        {
            this.productsService = productsService;
            this.userManager = userManager;
            this.categoriesService = categoriesService;
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

        [Authorize]
        public IActionResult Add()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            var viewModel = new CreateProductInputModel
            {
                Categories = this.categoriesService.GetAllAsSelectListItems(),
            };

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(CreateProductInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Categories = this.categoriesService.GetAllAsSelectListItems().ToList();
                return this.View(input);
            }

            input.UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.productsService.CreateAsync(input);

            //// TODO: Redirect to recipe info page
            return this.RedirectToAction("All");
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

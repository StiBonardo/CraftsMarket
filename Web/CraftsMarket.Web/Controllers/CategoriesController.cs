namespace CraftsMarket.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using CraftsMarket.Services.Data;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult All()
        {
            var viewModel = this.categoriesService.GetAll().ToList();
            return this.View(viewModel);
        }
    }
}

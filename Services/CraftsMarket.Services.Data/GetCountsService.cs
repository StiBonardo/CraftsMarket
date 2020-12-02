using System.Linq;
using CraftsMarket.Web.ViewModels.Home;

namespace CraftsMarket.Services.Data
{
    using CraftsMarket.Data.Common.Repositories;
    using CraftsMarket.Data.Models;

    public class GetCountsService : IGetCountsService
    {
        private readonly IDeletableEntityRepository<Product> productsRepository;
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public GetCountsService(
            IDeletableEntityRepository<Product> productsRepository,
            IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.productsRepository = productsRepository;
            this.categoriesRepository = categoriesRepository;
        }

        public IndexViewModel GetCounts()
        {
            return new IndexViewModel()
            {
                ProductsCount = this.productsRepository.AllAsNoTracking().Count(),
                CategoriesCount = this.categoriesRepository.AllAsNoTracking().Count(),
            };
        }
    }
}

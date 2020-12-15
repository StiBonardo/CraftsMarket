namespace CraftsMarket.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CraftsMarket.Data.Common.Repositories;
    using CraftsMarket.Data.Models;
    using CraftsMarket.Services.Mapping;
    using CraftsMarket.Web.ViewModels.Products;

    public class ProductsService : IProductsService
    {
        private readonly IDeletableEntityRepository<Product> productsRepository;
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public ProductsService(
            IDeletableEntityRepository<Product> productsRepository,
            IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.productsRepository = productsRepository;
            this.categoriesRepository = categoriesRepository;
        }

        public ProductViewModel ById(int id)
        {
            return this.productsRepository.AllAsNoTracking().To<ProductViewModel>().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ProductViewModel> All()
        {
            return this.productsRepository
                .AllAsNoTracking()
                .OrderByDescending(x => x.ModifiedOn)
                .ThenByDescending(x => x.CreatedOn)
                .To<ProductViewModel>()
                .ToList();
        }

        public IEnumerable<ProductViewModel> AllForUser(string userId)
        {
            return this.productsRepository
                .AllAsNoTracking()
                .Where(x => x.User.Id == userId)
                .To<ProductViewModel>()
                .ToList();
        }

        public IEnumerable<ProductViewModel> GetRecentProducts(int count = 12)
        {
            var allCategories = this.categoriesRepository.AllAsNoTracking().ToList();
            var allCategoriesCount = allCategories.Count;
            var categoriesToShow = new List<Category>();
            var random = new Random();

            if (allCategoriesCount == count)
            {
                categoriesToShow = allCategories;
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    categoriesToShow.Add(allCategories[random.Next(0, allCategoriesCount)]);
                }
            }

            var recentProducts = new List<ProductViewModel>();
            foreach (var category in categoriesToShow)
            {
                var product = this.productsRepository
                    .AllAsNoTracking()
                    .To<ProductViewModel>()
                    .ToList()
                    .FirstOrDefault(x => x.CategoryName == category.Name && !recentProducts.Contains(x));

                if (product != null)
                {
                    recentProducts.Add(product);
                }
            }

            return recentProducts;
        }
    }
}

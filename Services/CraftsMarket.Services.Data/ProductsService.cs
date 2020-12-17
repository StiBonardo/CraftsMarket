using System.Threading.Tasks;

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

        public ProductViewModel GetById(int id)
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

        public IEnumerable<ProductViewModel> AllForUser(string username)
        {
            return this.productsRepository
                .AllAsNoTracking()
                .Where(x => x.User.UserName == username)
                .To<ProductViewModel>()
                .ToList();
        }

        public IEnumerable<ProductViewModel> GetRecentProducts(int count = 12)
        {
            var categories = this.categoriesRepository
                .AllAsNoTracking()
                .Where(x => x.Products.Any())
                .OrderByDescending(x => x.Products.Count())
                .Take(count)
                .ToList();

            var allProductsCount = this.productsRepository.All().Count();
            count = count <= allProductsCount ? count : allProductsCount;

            var recentProducts = new List<ProductViewModel>();
            foreach (var category in categories)
            {
                var product = this.productsRepository
                    .AllAsNoTracking()
                    .OrderByDescending(x => x.CreatedOn)
                    .To<ProductViewModel>()
                    .ToList()
                    .First(x => x.CategoryName == category.Name);

                recentProducts.Add(product);
            }

            var random = new Random();
            while (recentProducts.Count < count)
            {
                var product = this.productsRepository
                    .AllAsNoTracking()
                    .OrderByDescending(x => x.CreatedOn)
                    .To<ProductViewModel>()
                    .ToList()
                    .First(x => recentProducts.All(y => y.Name != x.Name));
                recentProducts.Add(product);
            }

            return recentProducts;
        }

        public IEnumerable<ProductViewModel> AllFromCategory(string categoryName)
        {
            return this.productsRepository
                .AllAsNoTracking()
                .Where(x => x.Category.Name == categoryName)
                .OrderByDescending(x => x.CreatedOn)
                .ThenByDescending(x => x.ModifiedOn)
                .To<ProductViewModel>()
                .ToList();
        }

        public async Task CreateAsync(CreateProductInputModel model)
        {
            var product = new Product
            {
                CategoryId = this.categoriesRepository.All().First(x => x.Name == model.CategoryName).Id,
                InStock = model.InStock,
                Name = model.Name,
                Price = model.Price,
                UserId = model.UserId,
                Description = model.Description,
            };

            await this.productsRepository.AddAsync(product);
            await this.productsRepository.SaveChangesAsync();
        }
    }
}

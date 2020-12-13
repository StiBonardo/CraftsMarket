using System.Linq;

using CraftsMarket.Services.Mapping;

namespace CraftsMarket.Services.Data
{
    using System;
    using System.Collections.Generic;

    using CraftsMarket.Data.Common.Repositories;
    using CraftsMarket.Data.Models;
    using CraftsMarket.Web.ViewModels.Products;

    public class ProductsService : IProductsService
    {
        private readonly IDeletableEntityRepository<Product> productsRepository;

        public ProductsService(IDeletableEntityRepository<Product> productsRepository)
        {
            this.productsRepository = productsRepository;
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
    }
}

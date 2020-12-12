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

        public IEnumerable<ProductViewModel> All()
        {
            throw new NotImplementedException();
        }
    }
}

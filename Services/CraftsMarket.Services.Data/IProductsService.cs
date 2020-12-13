namespace CraftsMarket.Services.Data
{
    using System.Collections.Generic;

    using CraftsMarket.Web.ViewModels.Products;

    public interface IProductsService
    {
        ProductViewModel ById(int id);

        IEnumerable<ProductViewModel> All();

        IEnumerable<ProductViewModel> AllForUser(string userId);
    }
}

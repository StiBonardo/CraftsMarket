namespace CraftsMarket.Services.Data
{
    using System.Collections.Generic;

    using CraftsMarket.Web.ViewModels.Products;

    public interface IProductsService
    {
        IEnumerable<ProductViewModel> All();
    }
}

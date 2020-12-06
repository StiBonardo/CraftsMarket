namespace CraftsMarket.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CraftsMarket.Data.Models;
    using CraftsMarket.Web.ViewModels.Products;

    public interface IProductsService
    {
        IEnumerable<ProductViewModel> All();
    }
}

using System.Threading.Tasks;

namespace CraftsMarket.Services.Data
{
    using System.Collections.Generic;

    using CraftsMarket.Web.ViewModels.Products;

    public interface IProductsService
    {
        ProductViewModel GetById(int id);

        IEnumerable<ProductViewModel> All();

        IEnumerable<ProductViewModel> AllForUser(string userId);

        IEnumerable<ProductViewModel> GetRecentProducts(int count = 12);

        IEnumerable<ProductViewModel> AllFromCategory(string categoryName);

        Task CreateAsync(CreateProductInputModel model);
    }
}

namespace CraftsMarket.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using CraftsMarket.Web.ViewModels.Products;

    public class IndexViewModel
    {
        public IndexViewModel()
        {
            this.TopRecentProducts = new List<ProductViewModel>();
        }

        public int ProductsCount { get; set; }

        public int CategoriesCount { get; set; }

        public ICollection<ProductViewModel> TopRecentProducts { get; set; }
    }
}

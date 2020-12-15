namespace CraftsMarket.Web.ViewModels.Products
{
    using System.Collections.Generic;

    public class ListOfProductsViewModel
    {
        public ListOfProductsViewModel()
        {
            this.MyProducts = new List<ProductViewModel>();
            this.AllProducts = new List<ProductViewModel>();
        }

        public ICollection<ProductViewModel> MyProducts { get; set; }

        public ICollection<ProductViewModel> AllProducts { get; set; }
    }
}

namespace CraftsMarket.Web.ViewModels.Products
{
    using System.Collections.Generic;

    public class AllFromCategoryViewModel
    {
        public AllFromCategoryViewModel()
        {
            this.Products = new HashSet<ProductViewModel>();
        }

        public string CategoryName { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}

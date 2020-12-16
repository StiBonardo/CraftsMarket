namespace CraftsMarket.Services.Data
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public interface ICategoriesService
    {
        IEnumerable<string> GetAll();

        IEnumerable<SelectListItem> GetAllAsSelectListItems();
    }
}

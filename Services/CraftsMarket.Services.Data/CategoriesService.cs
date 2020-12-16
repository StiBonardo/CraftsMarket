using System.Web.Mvc;

namespace CraftsMarket.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CraftsMarket.Data.Common.Repositories;
    using CraftsMarket.Data.Models;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public CategoriesService(IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<string> GetAll()
        {
            return this.categoriesRepository.AllAsNoTracking().Select(x => x.Name);
        }

        public IEnumerable<SelectListItem> GetAllAsSelectListItems()
        {
            return this.categoriesRepository.All().Select(x => new SelectListItem
            {
                Value = x.Name,
                Text = x.Name,
            }).ToList();
        }
    }
}

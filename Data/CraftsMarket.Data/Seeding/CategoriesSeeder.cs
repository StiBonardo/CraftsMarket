namespace CraftsMarket.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CraftsMarket.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        private const string CategoriesNamesString =
            "Art, Knitting, Foods and drinks, Services, Trinkets, Minerals, Cosmetics, Machinery, Jewelry";

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Categories.Any())
            {
                var categoriesNames = CategoriesNamesString.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                var categories = new List<Category>();
                foreach (var name in categoriesNames)
                {
                    categories.Add(new Category { Name = name });
                }

                await dbContext.AddRangeAsync(categories);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}

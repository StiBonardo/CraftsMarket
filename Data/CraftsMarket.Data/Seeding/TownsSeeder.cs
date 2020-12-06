namespace CraftsMarket.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    using AngleSharp;

    using CraftsMarket.Data.Models;

    public class TownsSeeder : ISeeder
    {
        /// <summary>
        /// Retrieving Bulgarian Towns from Wikipedia.
        /// </summary>
        private static readonly Url Url = new Url(
            "https://bg.wikipedia.org/wiki/%D0%93%D1%80%D0%B0%D0%B4%D0%BE%D0%B2%D0%B5_%D0%B2_%D0%91%D1%8A%D0%BB%D0%B3%D0%B0%D1%80%D0%B8%D1%8F");

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var config = Configuration.Default.WithDefaultLoader();

            var context = BrowsingContext.New(config);

            var document = await context.OpenAsync(Url);

            var elements = document.QuerySelectorAll("td").Where(x => x.InnerHtml.Length > 200).ToList();
            var htmlElements = elements
                .Select(x => x.InnerHtml);

            var towns = new HashSet<Town>();
            var dbTownNames = dbContext
                .Towns
                .Select(x => x.Name)
                .ToArray();

            foreach (var html in htmlElements)
            {
                var afterTitleElement = html.Split("title=\"")[1];
                var townName = afterTitleElement.Split("\">")[0];

                if (townName.Trim().EndsWith("(град)"))
                {
                    townName = townName.Replace("(град)", string.Empty, true, CultureInfo.InvariantCulture);
                }

                if (townName == "Област Велико Търново")
                {
                    continue;
                }

                if (dbTownNames.Any(x => x == townName))
                {
                    continue;
                }

                towns.Add(new Town { Name = townName });
            }

            await dbContext.Towns.AddRangeAsync(towns.OrderBy(x => x.Name));
            await dbContext.SaveChangesAsync();
        }
    }
}

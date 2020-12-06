﻿namespace CraftsMarket.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using CraftsMarket.Data.Common.Repositories;
    using CraftsMarket.Data.Models;
    using CraftsMarket.Data.Repositories;
    using CraftsMarket.Services.Data;
    using CraftsMarket.Web.ViewModels;
    using CraftsMarket.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IGetCountsService getCountsService;

        public HomeController(IGetCountsService getCountsService)
        {
            this.getCountsService = getCountsService;
        }

        public IActionResult Index()
        {
            var viewModel = this.getCountsService.GetCounts();

            return this.View(viewModel);
        }

        public IActionResult About()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}

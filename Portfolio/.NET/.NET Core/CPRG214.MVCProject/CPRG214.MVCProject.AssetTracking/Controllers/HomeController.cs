using CPRG214.MVCProject.AssetTracking.Models;
using CPRG214.MVCProject.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG214.MVCProject.AssetTracking.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult GetAssetsByType(int id)
        {
            return ViewComponent("AssetsByType", id);
        }
        public IActionResult Index()
        {
            var types = AssetTypeManager.GetAsKeyValuePairs();
            var assetTypes = new SelectList(types, "Value", "Text");
            var list = assetTypes.ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "All Types",
                Value = "0"
            });
            ViewBag.AssetTypes = list;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

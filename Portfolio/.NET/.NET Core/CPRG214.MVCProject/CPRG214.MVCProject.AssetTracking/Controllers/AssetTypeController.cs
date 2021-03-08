using CPRG214.MVCProject.AssetTracking.Models;
using CPRG214.MVCProject.BLL;
using CPRG214.MVCProject.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG214.MVCProject.AssetTracking.Controllers
{
    public class AssetTypeController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AssetTypeViewModel newAssetTypeMV)
        {
            var newAssetType = new AssetType()
            {
                Name = newAssetTypeMV.Name
            };
            try
            {
                AssetTypeManager.Add(newAssetType);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}

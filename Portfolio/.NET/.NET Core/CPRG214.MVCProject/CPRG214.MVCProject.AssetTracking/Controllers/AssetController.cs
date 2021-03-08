using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPRG214.MVCProject.BLL;
using CPRG214.MVCProject.Domain;
using CPRG214.MVCProject.AssetTracking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CPRG214.MVCProject.AssetTracking.Controllers
{
    public class AssetController : Controller
    {
        public IActionResult Create()
        {
            var types = AssetTypeManager.GetAsKeyValuePairs();
            var list = new SelectList(types, "Value", "Text");
            ViewBag.AssetTypes = list;
            return View();
        }
        [HttpPost]
        public IActionResult Create(AssetViewModel newAssetMV)
        {
            var newAsset = new Asset()
            {
                Id = newAssetMV.Id,
                TagNumber = newAssetMV.TagNumber,
                AssetTypeId = newAssetMV.AssetTypeId,
                Manufacturer = newAssetMV.Manufacturer,
                Model = newAssetMV.Model,
                Description = newAssetMV.Description,
                SerialNumber = newAssetMV.SerialNumber
            };
            try
            {
                AssetManager.Add(newAsset);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}

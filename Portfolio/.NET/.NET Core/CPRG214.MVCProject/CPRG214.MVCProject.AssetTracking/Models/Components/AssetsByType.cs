using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPRG214.MVCProject.Domain;
using CPRG214.MVCProject.BLL;

namespace CPRG214.MVCProject.AssetTracking.Models.Components
{
    public class AssetsByType : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            //Get the model asynchronously and pass to the view (ViewModel)

            //Declare a local variable to store rental properties
            List<Asset> assets = null;

            //OK, this is a "hack" because I want to test if id is 0 (select all)
            if (id == 0)
            {
                //return all rentals if id is 0...
                assets = AssetManager.GetAll();
            }
            else
            {
                //...otherwise we will use the id in the query
                assets = AssetManager.GetAllByAssetType(id);
            }

            //Now we can transform whatever rental collection we have to a
            //collection of RentalsViewModel objects to pass to the view
            var assetModels = assets.
                Select(rp => new AssetViewModel
                {
                    Id = rp.Id,
                    TagNumber = rp.TagNumber,
                    AssetTypeId = rp.AssetTypeId,
                    Manufacturer = rp.Manufacturer,
                    Model = rp.Model,
                    Description = rp.Description,
                    SerialNumber = rp.SerialNumber,
                    AssetTypeName = AssetTypeManager.GetNameByTypeId(rp.AssetTypeId)
                }).ToList();

            //model given to the view
            return View(assetModels);
        }
    }
}

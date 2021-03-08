using CPRG214.MVCProject.Data;
using CPRG214.MVCProject.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CPRG214.MVCProject.BLL
{
    public class AssetManager
    {
        public static List<Asset> GetAll()
        {
            var context = new AssetsContext();
            var assets = context.Assets.ToList();
            return assets;
        }
        public static List<Asset> GetAllByAssetType(int id)
        {
            var context = new AssetsContext();
            List<Asset> assetsByType = new List<Asset>();
            using (context)
            {
                var query = from a in context.Assets
                            where a.AssetTypeId == id
                            select a;
                foreach(var asset in query)
                {
                    assetsByType.Add(asset);
                }
            }
            return assetsByType;
        }
        public static void Add(Asset asset)
        {
            var context = new AssetsContext();
            context.Assets.Add(asset);
            context.SaveChanges();
        }
    }
}

using CPRG214.MVCProject.Data;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CPRG214.MVCProject.Domain;

namespace CPRG214.MVCProject.BLL
{
    public class AssetTypeManager
    {
        public static IList GetAsKeyValuePairs()
        {
            var context = new AssetsContext();
            var types = context.AssetTypes.Select(a => new
            {
                Value = a.Id,
                Text = a.Name
            }).ToList();
            return types;
        }
        public static void Add(AssetType assetType)
        {
            var context = new AssetsContext();
            context.AssetTypes.Add(assetType);
            context.SaveChanges();
        }
        public static string GetNameByTypeId(int typeId)
        {
            var context = new AssetsContext();
            string result = (from at in context.AssetTypes
                        where at.Id == typeId
                        select at.Name).First().ToString();
            return result;
        }
    }
}

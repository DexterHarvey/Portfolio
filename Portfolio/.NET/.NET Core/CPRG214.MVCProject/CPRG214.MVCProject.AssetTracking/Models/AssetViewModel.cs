using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG214.MVCProject.AssetTracking.Models
{
    public class AssetViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tag #")]
        public string TagNumber { get; set; }
        [Required]
        [Display(Name = "Asset Type Id")]
        public int AssetTypeId { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Serial #")]
        public string SerialNumber { get; set; }
        [Display(Name = "Asset Type")]
        public string AssetTypeName { get; set; }
    }
}

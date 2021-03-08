using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPRG214.MVCProject.Domain
{
    [Table("Asset")]
    public class Asset
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string TagNumber { get; set; }
        [Required]
        public int AssetTypeId { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string SerialNumber { get; set; }
    }
}

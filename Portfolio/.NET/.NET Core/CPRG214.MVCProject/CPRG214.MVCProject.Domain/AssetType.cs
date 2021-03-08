﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPRG214.MVCProject.Domain
{
    [Table("AssetType")]
    public class AssetType
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //navigation property
        public ICollection<Asset> Assets { get; set; } 
    }
}

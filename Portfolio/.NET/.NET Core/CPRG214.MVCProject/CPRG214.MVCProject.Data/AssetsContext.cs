using CPRG214.MVCProject.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPRG214.MVCProject.Data
{
    public class AssetsContext : DbContext
    {
        public AssetsContext() : base() { }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=sait228152oosd\\sqlexpress;Database=Assets;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AssetType>().HasData(
                new AssetType { Id = 1, Name = "Computer" },
                new AssetType { Id = 2, Name = "Monitor" },
                new AssetType { Id = 3, Name = "Phone" }
                );
            modelBuilder.Entity<Asset>().HasData(
                new Asset
                {
                    Id = 1,
                    TagNumber = "123asd890",
                    AssetTypeId = 2,
                    Manufacturer = "Acer",
                    Description = "40\" Curved Gaming Monitor 120Hz",
                    SerialNumber = "1234567890"
                },
                new Asset
                {
                    Id = 2,
                    TagNumber = "456ghj815",
                    AssetTypeId = 1,
                    Manufacturer = "Dell",
                    Description = "Intel i7gsad35 Professional Laptop",
                    SerialNumber = "09843253212"
                },
                new Asset
                {
                    Id = 3,
                    TagNumber = "897csn731",
                    AssetTypeId = 3,
                    Manufacturer = "Avaya",
                    Description = "TrustLink Home Phone",
                    SerialNumber = "0986412792"
                },
                new Asset
                {
                    Id = 4,
                    TagNumber = "382agc952",
                    AssetTypeId = 3,
                    Manufacturer = "Cisco",
                    Description = "ConnectSoft Office Phone Solution",
                    SerialNumber = "5870321469"
                },
                new Asset
                {
                    Id = 5,
                    TagNumber = "507bap394",
                    AssetTypeId = 1,
                    Manufacturer = "HP",
                    Description = "AMD Rx950 Gaming Laptop",
                    SerialNumber = "8432079465"
                },
                new Asset
                {
                    Id = 6,
                    TagNumber = "403dal986",
                    AssetTypeId = 2,
                    Manufacturer = "LG",
                    Description = "27\" Business Monitor",
                    SerialNumber = "4032594503"
                },
                new Asset
                {
                    Id = 7,
                    TagNumber = "650fmc871",
                    AssetTypeId = 1,
                    Manufacturer = "Dell",
                    Description = "Intel i3asd20Ghz WorkSoft Laptop",
                    SerialNumber = "6501424987"
                },
                new Asset
                {
                    Id = 8,
                    TagNumber = "987asn782",
                    AssetTypeId = 3,
                    Manufacturer = "Polycom",
                    Description = "WorkMax Office Phone with Voicemail",
                    SerialNumber = "7785103912"
                },
                new Asset
                {
                    Id = 9,
                    TagNumber = "952hha560",
                    AssetTypeId = 1,
                    Manufacturer = "Acer",
                    Description = "Intel i3 Office Desktop",
                    SerialNumber = "5674058701"
                },
                new Asset
                {
                    Id = 10,
                    TagNumber = "627jvc892",
                    AssetTypeId = 2,
                    Manufacturer = "Acer",
                    Description = "60\" Ultrawide IPS Monitor",
                    SerialNumber = "7156087856"
                }
                );
        }
    }
}

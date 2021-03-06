// <auto-generated />
using CPRG214.MVCProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CPRG214.MVCProject.Data.Migrations
{
    [DbContext(typeof(AssetsContext))]
    partial class AssetsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("CPRG214.MVCProject.Domain.Asset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AssetTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TagNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssetTypeId");

                    b.ToTable("Asset");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssetTypeId = 2,
                            Description = "40\" Curved Gaming Monitor 120Hz",
                            Manufacturer = "Acer",
                            SerialNumber = "1234567890",
                            TagNumber = "123asd890"
                        },
                        new
                        {
                            Id = 2,
                            AssetTypeId = 1,
                            Description = "Intel i7gsad35 Professional Laptop",
                            Manufacturer = "Dell",
                            SerialNumber = "09843253212",
                            TagNumber = "456ghj815"
                        },
                        new
                        {
                            Id = 3,
                            AssetTypeId = 3,
                            Description = "TrustLink Home Phone",
                            Manufacturer = "Avaya",
                            SerialNumber = "0986412792",
                            TagNumber = "897csn731"
                        },
                        new
                        {
                            Id = 4,
                            AssetTypeId = 3,
                            Description = "ConnectSoft Office Phone Solution",
                            Manufacturer = "Cisco",
                            SerialNumber = "5870321469",
                            TagNumber = "382agc952"
                        },
                        new
                        {
                            Id = 5,
                            AssetTypeId = 1,
                            Description = "AMD Rx950 Gaming Laptop",
                            Manufacturer = "HP",
                            SerialNumber = "8432079465",
                            TagNumber = "507bap394"
                        },
                        new
                        {
                            Id = 6,
                            AssetTypeId = 2,
                            Description = "27\" Business Monitor",
                            Manufacturer = "LG",
                            SerialNumber = "4032594503",
                            TagNumber = "403dal986"
                        },
                        new
                        {
                            Id = 7,
                            AssetTypeId = 1,
                            Description = "Intel i3asd20Ghz WorkSoft Laptop",
                            Manufacturer = "Dell",
                            SerialNumber = "6501424987",
                            TagNumber = "650fmc871"
                        },
                        new
                        {
                            Id = 8,
                            AssetTypeId = 3,
                            Description = "WorkMax Office Phone with Voicemail",
                            Manufacturer = "Polycom",
                            SerialNumber = "7785103912",
                            TagNumber = "987asn782"
                        },
                        new
                        {
                            Id = 9,
                            AssetTypeId = 1,
                            Description = "Intel i3 Office Desktop",
                            Manufacturer = "Acer",
                            SerialNumber = "5674058701",
                            TagNumber = "952hha560"
                        },
                        new
                        {
                            Id = 10,
                            AssetTypeId = 2,
                            Description = "60\" Ultrawide IPS Monitor",
                            Manufacturer = "Acer",
                            SerialNumber = "7156087856",
                            TagNumber = "627jvc892"
                        });
                });

            modelBuilder.Entity("CPRG214.MVCProject.Domain.AssetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AssetType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Computer"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Monitor"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Phone"
                        });
                });

            modelBuilder.Entity("CPRG214.MVCProject.Domain.Asset", b =>
                {
                    b.HasOne("CPRG214.MVCProject.Domain.AssetType", null)
                        .WithMany("Assets")
                        .HasForeignKey("AssetTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CPRG214.MVCProject.Domain.AssetType", b =>
                {
                    b.Navigation("Assets");
                });
#pragma warning restore 612, 618
        }
    }
}

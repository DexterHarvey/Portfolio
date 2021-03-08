using Microsoft.EntityFrameworkCore.Migrations;

namespace CPRG214.MVCProject.Data.Migrations
{
    public partial class CreateAssets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetTypeId = table.Column<int>(type: "int", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asset_AssetType_AssetTypeId",
                        column: x => x.AssetTypeId,
                        principalTable: "AssetType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AssetType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Computer" });

            migrationBuilder.InsertData(
                table: "AssetType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Monitor" });

            migrationBuilder.InsertData(
                table: "AssetType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Phone" });

            migrationBuilder.InsertData(
                table: "Asset",
                columns: new[] { "Id", "AssetTypeId", "Description", "Manufacturer", "Model", "SerialNumber", "TagNumber" },
                values: new object[,]
                {
                    { 2, 1, "Intel i7gsad35 Professional Laptop", "Dell", null, "09843253212", "456ghj815" },
                    { 5, 1, "AMD Rx950 Gaming Laptop", "HP", null, "8432079465", "507bap394" },
                    { 7, 1, "Intel i3asd20Ghz WorkSoft Laptop", "Dell", null, "6501424987", "650fmc871" },
                    { 9, 1, "Intel i3 Office Desktop", "Acer", null, "5674058701", "952hha560" },
                    { 1, 2, "40\" Curved Gaming Monitor 120Hz", "Acer", null, "1234567890", "123asd890" },
                    { 6, 2, "27\" Business Monitor", "LG", null, "4032594503", "403dal986" },
                    { 10, 2, "60\" Ultrawide IPS Monitor", "Acer", null, "7156087856", "627jvc892" },
                    { 3, 3, "TrustLink Home Phone", "Avaya", null, "0986412792", "897csn731" },
                    { 4, 3, "ConnectSoft Office Phone Solution", "Cisco", null, "5870321469", "382agc952" },
                    { 8, 3, "WorkMax Office Phone with Voicemail", "Polycom", null, "7785103912", "987asn782" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_AssetTypeId",
                table: "Asset",
                column: "AssetTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "AssetType");
        }
    }
}

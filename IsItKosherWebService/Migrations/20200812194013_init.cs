using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IsItKosherWebService.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KosherCertifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RabbiFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RabbiLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KosherCertifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KosherSymbols",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<byte[]>(type: "image", nullable: true),
                    KosherCertificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KosherSymbols", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KosherSymbols_KosherCertifications_KosherCertificationId",
                        column: x => x.KosherCertificationId,
                        principalTable: "KosherCertifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    Longitude = table.Column<float>(type: "real", nullable: false),
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    KosherCertificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_KosherCertifications_KosherCertificationId",
                        column: x => x.KosherCertificationId,
                        principalTable: "KosherCertifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "KosherCertifications",
                columns: new[] { "Id", "Name", "PhoneNumber", "RabbiFirstName", "RabbiLastName" },
                values: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Ok Kosher", "6462714233", "Rabbi Tzvi", "Tornek" });

            migrationBuilder.InsertData(
                table: "KosherSymbols",
                columns: new[] { "Id", "Image", "ImageDescription", "KosherCertificationId" },
                values: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new byte[0], "k inside of a circle", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35") });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "City", "Country", "KosherCertificationId", "Latitude", "Longitude", "State", "Street", "ZipCode" },
                values: new object[] { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"), "brooklyn", "USA", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), 200f, 100f, "Ny", "1417 east 16th street", 11225 });

            migrationBuilder.CreateIndex(
                name: "IX_KosherSymbols_KosherCertificationId",
                table: "KosherSymbols",
                column: "KosherCertificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_KosherCertificationId",
                table: "Locations",
                column: "KosherCertificationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KosherSymbols");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "KosherCertifications");
        }
    }
}

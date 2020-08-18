using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IsItKosherWebService.Migrations
{
    public partial class ChangedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "KosherCertifications",
                columns: new[] { "Id", "Name", "PhoneNumber", "RabbiFirstName", "RabbiLastName" },
                values: new object[] { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "Orthodox Union", "2628945438", "Rabbi Tova", "Tornek" });

            migrationBuilder.InsertData(
                table: "KosherSymbols",
                columns: new[] { "Id", "Image", "ImageDescription", "KosherCertificationId" },
                values: new object[] { new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"), new byte[0], "U inside of a circle", new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96") });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "City", "Country", "KosherCertificationId", "Latitude", "Longitude", "State", "Street", "ZipCode" },
                values: new object[] { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), "brooklyn", "USA", new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), 1000f, -200f, "Ny", "1166 50th street", 11219 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "KosherSymbols",
                keyColumn: "Id",
                keyValue: new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"));

            migrationBuilder.DeleteData(
                table: "KosherCertifications",
                keyColumn: "Id",
                keyValue: new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"));
        }
    }
}

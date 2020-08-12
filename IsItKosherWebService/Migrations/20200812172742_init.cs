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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RabbiFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RabbiLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false)
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
                    Image = table.Column<byte[]>(type: "image", nullable: false),
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

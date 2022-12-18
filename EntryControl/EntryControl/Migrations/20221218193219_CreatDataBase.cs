using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntryControl.Migrations
{
    /// <inheritdoc />
    public partial class CreatDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Action = table.Column<int>(type: "int", nullable: false),
                    EventType = table.Column<int>(type: "int", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: false),
                    GateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GateAccess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GateId = table.Column<int>(type: "int", nullable: false),
                    AuthorizationType = table.Column<int>(type: "int", nullable: false),
                    EventType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GateAccess", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GateId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvenTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorizationLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportWorkHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: false),
                    WorkSeconds = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportWorkHours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkerId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorizationLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "GateAccess",
                columns: new[] { "Id", "AuthorizationType", "EventType", "GateId" },
                values: new object[,]
                {
                    { 1, 0, 0, 1 },
                    { 2, 0, 0, 2 },
                    { 3, 0, 0, 3 },
                    { 4, 0, 0, 4 },
                    { 5, 1, 0, 1 },
                    { 6, 1, 0, 2 },
                    { 7, 1, 0, 3 },
                    { 8, 1, 1, 4 },
                    { 9, 2, 0, 1 },
                    { 10, 2, 1, 2 },
                    { 11, 2, 0, 3 },
                    { 12, 2, 0, 4 },
                    { 13, 3, 1, 1 },
                    { 14, 3, 1, 2 },
                    { 15, 3, 0, 3 },
                    { 16, 3, 0, 4 }
                });

            migrationBuilder.InsertData(
                table: "Gates",
                columns: new[] { "Id", "Description", "GateId", "Name" },
                values: new object[,]
                {
                    { 1, "Lab", 1050, 2 },
                    { 2, "Warehouse", 2030, 0 },
                    { 3, "Office", 2041, 3 },
                    { 4, "Central", 1045, 1 }
                });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "AuthorizationLevel", "Description", "Name", "Surname", "WorkerId" },
                values: new object[,]
                {
                    { 1, 0, null, "Carson", "Alexander", 1 },
                    { 2, 2, null, "Meredith", "Alonso", 2 },
                    { 3, 1, null, "Arturo", "Anand", 3 },
                    { 4, 3, null, "Gytis", "Barzdukas", 4 },
                    { 5, 2, null, "Yan", "Li", 5 },
                    { 6, 3, null, "Peggy", "Justice", 6 },
                    { 7, 3, null, "Laura", "Norman", 7 },
                    { 8, 3, null, "Nino", "Rustin", 8 },
                    { 9, 3, null, "Jonas", "Petraitis", 9 },
                    { 10, 3, null, "Simonas", "Galinis", 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "GateAccess");

            migrationBuilder.DropTable(
                name: "Gates");

            migrationBuilder.DropTable(
                name: "ReportEvents");

            migrationBuilder.DropTable(
                name: "ReportWorkHours");

            migrationBuilder.DropTable(
                name: "Workers");
        }
    }
}

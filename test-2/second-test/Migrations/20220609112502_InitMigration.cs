using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace second_test.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "s23499");

            migrationBuilder.CreateTable(
                name: "Action",
                schema: "s23499",
                columns: table => new
                {
                    IdAction = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    NeedSpecialEquipment = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Action_pk", x => x.IdAction);
                });

            migrationBuilder.CreateTable(
                name: "Firefighter",
                schema: "s23499",
                columns: table => new
                {
                    IdFirefighter = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Firefighter_pk", x => x.IdFirefighter);
                });

            migrationBuilder.CreateTable(
                name: "FireTruck",
                schema: "s23499",
                columns: table => new
                {
                    IdFireTruck = table.Column<int>(type: "int", nullable: false),
                    OperationalNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SpecialEquipment = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("FireTruck_pk", x => x.IdFireTruck);
                });

            migrationBuilder.CreateTable(
                name: "Firefighter_Action",
                schema: "s23499",
                columns: table => new
                {
                    IdFirefighter = table.Column<int>(type: "int", nullable: false),
                    IdAction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Firefighter_Action_pk", x => new { x.IdFirefighter, x.IdAction });
                    table.ForeignKey(
                        name: "Firefighter_Action_Action",
                        column: x => x.IdAction,
                        principalSchema: "s23499",
                        principalTable: "Action",
                        principalColumn: "IdAction");
                    table.ForeignKey(
                        name: "Firefighter_Action_Firefighter",
                        column: x => x.IdFirefighter,
                        principalSchema: "s23499",
                        principalTable: "Firefighter",
                        principalColumn: "IdFirefighter");
                });

            migrationBuilder.CreateTable(
                name: "Firetruck_Action",
                schema: "s23499",
                columns: table => new
                {
                    IdFireTruckAction = table.Column<int>(type: "int", nullable: false),
                    AssignmentDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdFireTruck = table.Column<int>(type: "int", nullable: false),
                    IdAction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Firetruck_Action_pk", x => x.IdFireTruckAction);
                    table.ForeignKey(
                        name: "Firetruck_Action_Action",
                        column: x => x.IdAction,
                        principalSchema: "s23499",
                        principalTable: "Action",
                        principalColumn: "IdAction");
                    table.ForeignKey(
                        name: "Firetruck_Action_FireTruck",
                        column: x => x.IdFireTruck,
                        principalSchema: "s23499",
                        principalTable: "FireTruck",
                        principalColumn: "IdFireTruck");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Firefighter_Action_IdAction",
                schema: "s23499",
                table: "Firefighter_Action",
                column: "IdAction");

            migrationBuilder.CreateIndex(
                name: "IX_Firetruck_Action_IdAction",
                schema: "s23499",
                table: "Firetruck_Action",
                column: "IdAction");

            migrationBuilder.CreateIndex(
                name: "IX_Firetruck_Action_IdFireTruck",
                schema: "s23499",
                table: "Firetruck_Action",
                column: "IdFireTruck");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Firefighter_Action",
                schema: "s23499");

            migrationBuilder.DropTable(
                name: "Firetruck_Action",
                schema: "s23499");

            migrationBuilder.DropTable(
                name: "Firefighter",
                schema: "s23499");

            migrationBuilder.DropTable(
                name: "Action",
                schema: "s23499");

            migrationBuilder.DropTable(
                name: "FireTruck",
                schema: "s23499");
        }
    }
}

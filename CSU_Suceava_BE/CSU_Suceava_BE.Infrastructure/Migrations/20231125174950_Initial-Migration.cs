using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSU_Suceava_BE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meci",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipCampionat = table.Column<int>(type: "int", nullable: false),
                    Editia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusMeci = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeAdversar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locatia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkLive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Acasa = table.Column<bool>(type: "bit", nullable: false),
                    ScorCSUSV = table.Column<int>(type: "int", nullable: false),
                    ScorAdversar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nationalitate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TipLot = table.Column<int>(type: "int", precision: 1, nullable: false),
                    Post = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    URLPoza = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    DataNastere = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Inaltime = table.Column<double>(type: "float(3)", precision: 3, scale: 2, nullable: false),
                    Descriere = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilizator",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Parola = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IstoricPremii",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumePremiu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataPrimire = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IstoricPremii", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IstoricPremii_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IstoricRoluri",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeRol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataIncepere = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFinalizare = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IstoricRoluri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IstoricRoluri_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stire",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titlu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Continut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashTaguri = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StatusStire = table.Column<int>(type: "int", precision: 1, nullable: false),
                    DataAutopostare = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPostare = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UtilizatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stire", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stire_Utilizator_UtilizatorId",
                        column: x => x.UtilizatorId,
                        principalTable: "Utilizator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IstoricPremii_StaffId",
                table: "IstoricPremii",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_IstoricRoluri_StaffId",
                table: "IstoricRoluri",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Stire_UtilizatorId",
                table: "Stire",
                column: "UtilizatorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IstoricPremii");

            migrationBuilder.DropTable(
                name: "IstoricRoluri");

            migrationBuilder.DropTable(
                name: "Meci");

            migrationBuilder.DropTable(
                name: "Stire");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Utilizator");
        }
    }
}

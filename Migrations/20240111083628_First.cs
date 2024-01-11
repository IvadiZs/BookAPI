using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookAPI.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "nemzetiseg",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(50)", maxLength: 50, nullable: false, collation: "ascii_general_ci"),
                    szerzonemz = table.Column<string>(name: "szerzo_nemz", type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "szerzo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(50)", maxLength: 50, nullable: false, collation: "ascii_general_ci"),
                    nev = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nem = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nemzid = table.Column<Guid>(name: "nemz_id", type: "char(50)", maxLength: 50, nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "szerzo_ibfk_1",
                        column: x => x.nemzid,
                        principalTable: "nemzetiseg",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "konyv",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(50)", maxLength: 50, nullable: false, collation: "ascii_general_ci"),
                    cim = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    oldalszam = table.Column<int>(type: "int(11)", nullable: false),
                    kiadev = table.Column<int>(type: "int(11)", nullable: false),
                    szerzoid = table.Column<Guid>(name: "szerzo_id", type: "char(50)", maxLength: 50, nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "konyv_ibfk_1",
                        column: x => x.szerzoid,
                        principalTable: "szerzo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateIndex(
                name: "szerzo_id",
                table: "konyv",
                column: "szerzo_id");

            migrationBuilder.CreateIndex(
                name: "nemz_id",
                table: "szerzo",
                column: "nemz_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "konyv");

            migrationBuilder.DropTable(
                name: "szerzo");

            migrationBuilder.DropTable(
                name: "nemzetiseg");
        }
    }
}

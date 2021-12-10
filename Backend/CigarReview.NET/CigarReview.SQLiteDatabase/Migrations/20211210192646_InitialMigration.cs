using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CigarReview.SQLiteDatabase.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CigarBrand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CigarBrand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CigarOrigin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CigarOrigin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CigarShade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CigarShade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CigarShape",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CigarShape", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CigarStrength",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CigarStrength", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TobaccoType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TobaccoType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cigars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BrandId = table.Column<int>(type: "INTEGER", nullable: true),
                    Length = table.Column<decimal>(type: "TEXT", nullable: false),
                    RingSize = table.Column<int>(type: "INTEGER", nullable: false),
                    ShapeId = table.Column<int>(type: "INTEGER", nullable: true),
                    ShadeId = table.Column<int>(type: "INTEGER", nullable: true),
                    WrapperId = table.Column<int>(type: "INTEGER", nullable: true),
                    BinderId = table.Column<int>(type: "INTEGER", nullable: true),
                    FillerId = table.Column<int>(type: "INTEGER", nullable: true),
                    OriginId = table.Column<int>(type: "INTEGER", nullable: true),
                    StrengthId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cigars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cigars_CigarBrand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "CigarBrand",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cigars_CigarOrigin_OriginId",
                        column: x => x.OriginId,
                        principalTable: "CigarOrigin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cigars_CigarShade_ShadeId",
                        column: x => x.ShadeId,
                        principalTable: "CigarShade",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cigars_CigarShape_ShapeId",
                        column: x => x.ShapeId,
                        principalTable: "CigarShape",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cigars_CigarStrength_StrengthId",
                        column: x => x.StrengthId,
                        principalTable: "CigarStrength",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cigars_TobaccoType_BinderId",
                        column: x => x.BinderId,
                        principalTable: "TobaccoType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cigars_TobaccoType_FillerId",
                        column: x => x.FillerId,
                        principalTable: "TobaccoType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cigars_TobaccoType_WrapperId",
                        column: x => x.WrapperId,
                        principalTable: "TobaccoType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cigars_BinderId",
                table: "Cigars",
                column: "BinderId");

            migrationBuilder.CreateIndex(
                name: "IX_Cigars_BrandId",
                table: "Cigars",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Cigars_FillerId",
                table: "Cigars",
                column: "FillerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cigars_OriginId",
                table: "Cigars",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Cigars_ShadeId",
                table: "Cigars",
                column: "ShadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cigars_ShapeId",
                table: "Cigars",
                column: "ShapeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cigars_StrengthId",
                table: "Cigars",
                column: "StrengthId");

            migrationBuilder.CreateIndex(
                name: "IX_Cigars_WrapperId",
                table: "Cigars",
                column: "WrapperId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cigars");

            migrationBuilder.DropTable(
                name: "CigarBrand");

            migrationBuilder.DropTable(
                name: "CigarOrigin");

            migrationBuilder.DropTable(
                name: "CigarShade");

            migrationBuilder.DropTable(
                name: "CigarShape");

            migrationBuilder.DropTable(
                name: "CigarStrength");

            migrationBuilder.DropTable(
                name: "TobaccoType");
        }
    }
}

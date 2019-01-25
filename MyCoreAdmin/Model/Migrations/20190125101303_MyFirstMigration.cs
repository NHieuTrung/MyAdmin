using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BRANCH",
                columns: table => new
                {
                    BranchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchName = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRANCH", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "TYPE",
                columns: table => new
                {
                    TypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeName = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TYPE", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "ATTRIBUTE",
                columns: table => new
                {
                    AttributeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeId = table.Column<int>(nullable: true),
                    AttributeName = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTRIBUTE", x => x.AttributeId);
                    table.ForeignKey(
                        name: "FK_ATTRIBUTE_TYPE",
                        column: x => x.TypeId,
                        principalTable: "TYPE",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(maxLength: 100, nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EstablishedDate = table.Column<DateTime>(type: "date", nullable: true),
                    TypeId = table.Column<int>(nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_PRODUCT_BRANCH",
                        column: x => x.BranchId,
                        principalTable: "BRANCH",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRODUCT_TYPE",
                        column: x => x.TypeId,
                        principalTable: "TYPE",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_ATTRIBUTE",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    AttributeId = table.Column<int>(nullable: false),
                    AttributeValue = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PRODUCT___081454530E839143", x => new { x.ProductId, x.AttributeId });
                    table.ForeignKey(
                        name: "FK_PRODUCT_ATTRIBUTE_ATTRIBUTE1",
                        column: x => x.AttributeId,
                        principalTable: "ATTRIBUTE",
                        principalColumn: "AttributeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRODUCT_ATTRIBUTE_PRODUCT",
                        column: x => x.ProductId,
                        principalTable: "PRODUCT",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ATTRIBUTE_TypeId",
                table: "ATTRIBUTE",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_BranchId",
                table: "PRODUCT",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_TypeId",
                table: "PRODUCT",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_ATTRIBUTE_AttributeId",
                table: "PRODUCT_ATTRIBUTE",
                column: "AttributeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUCT_ATTRIBUTE");

            migrationBuilder.DropTable(
                name: "ATTRIBUTE");

            migrationBuilder.DropTable(
                name: "PRODUCT");

            migrationBuilder.DropTable(
                name: "BRANCH");

            migrationBuilder.DropTable(
                name: "TYPE");
        }
    }
}

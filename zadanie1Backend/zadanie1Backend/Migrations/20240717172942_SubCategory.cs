using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zadanie1Backend.Migrations
{
    /// <inheritdoc />
    public partial class SubCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "Contacts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_SubCategoryId",
                table: "Contacts",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_SubCategory_SubCategoryId",
                table: "Contacts",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_SubCategory_SubCategoryId",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_SubCategoryId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "Contacts");
        }
    }
}

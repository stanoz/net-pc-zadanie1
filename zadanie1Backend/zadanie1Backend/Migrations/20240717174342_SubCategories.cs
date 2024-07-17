using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zadanie1Backend.Migrations
{
    /// <inheritdoc />
    public partial class SubCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_SubCategory_SubCategoryId",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategory",
                table: "SubCategory");

            migrationBuilder.RenameTable(
                name: "SubCategory",
                newName: "SubCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategories",
                table: "SubCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_SubCategories_SubCategoryId",
                table: "Contacts",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_SubCategories_SubCategoryId",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategories",
                table: "SubCategories");

            migrationBuilder.RenameTable(
                name: "SubCategories",
                newName: "SubCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategory",
                table: "SubCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_SubCategory_SubCategoryId",
                table: "Contacts",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "Id");
        }
    }
}

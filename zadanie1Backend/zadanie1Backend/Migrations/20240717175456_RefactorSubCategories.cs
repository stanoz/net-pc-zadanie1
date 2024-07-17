using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zadanie1Backend.Migrations
{
    /// <inheritdoc />
    public partial class RefactorSubCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "SubCategories");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "SubCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "SubCategories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "SubCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

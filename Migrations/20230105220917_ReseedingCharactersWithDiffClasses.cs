using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPG.Migrations
{
    /// <inheritdoc />
    public partial class ReseedingCharactersWithDiffClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 2,
                column: "Class",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 3,
                column: "Class",
                value: 6);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 2,
                column: "Class",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 3,
                column: "Class",
                value: 1);
        }
    }
}

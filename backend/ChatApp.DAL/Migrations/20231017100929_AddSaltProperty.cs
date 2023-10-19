using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddSaltProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Salt",
                value: "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Salt",
                value: "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Salt",
                value: "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Salt",
                value: "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Salt",
                value: "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Salt",
                value: "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Salt",
                value: "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Salt",
                value: "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Salt",
                value: "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Salt",
                value: "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Salt",
                value: "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Salt",
                value: "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Salt",
                value: "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Salt",
                value: "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Salt",
                value: "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "Salt",
                value: "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "Salt",
                value: "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 18,
                column: "Salt",
                value: "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 19,
                column: "Salt",
                value: "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 20,
                column: "Salt",
                value: "SkApdc90bA/0vsJNHgTrS7WY/qhGtWohhkaC/hDkhBo=");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Users");
        }
    }
}

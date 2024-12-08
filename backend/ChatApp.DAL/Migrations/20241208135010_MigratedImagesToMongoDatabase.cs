using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class MigratedImagesToMongoDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Users",
                newName: "ImageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Users",
                newName: "ImagePath");
        }
    }
}

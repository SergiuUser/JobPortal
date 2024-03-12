using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortalAPI.Migrations
{
    /// <inheritdoc />
    public partial class JobPortalMigration_V4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Peson",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Peson");
        }
    }
}

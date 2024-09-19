using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImageSliderApp.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomToOverlay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
            name: "Room",
            table: "Overlays",
            type: "varchar(255)",
            nullable: true);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
            name: "Room",
            table: "Overlays");

        }
    }
}

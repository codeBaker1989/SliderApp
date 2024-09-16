using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImageSliderApp.Migrations
{
    /// <inheritdoc />
    public partial class AllowNullForTemplateFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HallTemplates");

            migrationBuilder.DropTable(
                name: "Halls");

            migrationBuilder.CreateTable(
                name: "Overlay",
                columns: table => new
                {
                    OverlayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Position = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TemplateID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Overlay", x => x.OverlayID);
                    table.ForeignKey(
                        name: "FK_Overlay_Templates_TemplateID",
                        column: x => x.TemplateID,
                        principalTable: "Templates",
                        principalColumn: "TemplateID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoomName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RoomTemplates",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    TemplateID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTemplates", x => new { x.RoomID, x.TemplateID });
                    table.ForeignKey(
                        name: "FK_RoomTemplates_Rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "RoomID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomTemplates_Templates_TemplateID",
                        column: x => x.TemplateID,
                        principalTable: "Templates",
                        principalColumn: "TemplateID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Overlay_TemplateID",
                table: "Overlay",
                column: "TemplateID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomTemplates_TemplateID",
                table: "RoomTemplates",
                column: "TemplateID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Overlay");

            migrationBuilder.DropTable(
                name: "RoomTemplates");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.CreateTable(
                name: "Halls",
                columns: table => new
                {
                    HallID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HallName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Halls", x => x.HallID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HallTemplates",
                columns: table => new
                {
                    HallID = table.Column<int>(type: "int", nullable: false),
                    TemplateID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HallTemplates", x => new { x.HallID, x.TemplateID });
                    table.ForeignKey(
                        name: "FK_HallTemplates_Halls_HallID",
                        column: x => x.HallID,
                        principalTable: "Halls",
                        principalColumn: "HallID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HallTemplates_Templates_TemplateID",
                        column: x => x.TemplateID,
                        principalTable: "Templates",
                        principalColumn: "TemplateID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_HallTemplates_TemplateID",
                table: "HallTemplates",
                column: "TemplateID");
        }
    }
}

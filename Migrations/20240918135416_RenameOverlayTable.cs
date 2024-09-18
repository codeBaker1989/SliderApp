using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImageSliderApp.Migrations
{
    /// <inheritdoc />
    public partial class RenameOverlayTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Overlay_Templates_TemplateID",
                table: "Overlay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Overlay",
                table: "Overlay");

            migrationBuilder.RenameTable(
                name: "Overlay",
                newName: "Overlays");

            migrationBuilder.RenameIndex(
                name: "IX_Overlay_TemplateID",
                table: "Overlays",
                newName: "IX_Overlays_TemplateID");

            migrationBuilder.AlterColumn<string>(
                name: "TemplateName",
                table: "Templates",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "TemplateImagePath",
                table: "Templates",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "RoomName",
                table: "Rooms",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "Overlays",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Overlays",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Overlays",
                table: "Overlays",
                column: "OverlayID");

            migrationBuilder.AddForeignKey(
                name: "FK_Overlays_Templates_TemplateID",
                table: "Overlays",
                column: "TemplateID",
                principalTable: "Templates",
                principalColumn: "TemplateID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameTable(
                name: "Overlay",
                newName: "Overlays");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Overlays_Templates_TemplateID",
                table: "Overlays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Overlays",
                table: "Overlays");

            migrationBuilder.RenameTable(
                name: "Overlays",
                newName: "Overlay");

            migrationBuilder.RenameIndex(
                name: "IX_Overlays_TemplateID",
                table: "Overlay",
                newName: "IX_Overlay_TemplateID");

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "TemplateName",
                keyValue: null,
                column: "TemplateName",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "TemplateName",
                table: "Templates",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "TemplateImagePath",
                keyValue: null,
                column: "TemplateImagePath",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "TemplateImagePath",
                table: "Templates",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomName",
                keyValue: null,
                column: "RoomName",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "RoomName",
                table: "Rooms",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Overlay",
                keyColumn: "Position",
                keyValue: null,
                column: "Position",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "Overlay",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Overlay",
                keyColumn: "Content",
                keyValue: null,
                column: "Content",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Overlay",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Overlay",
                table: "Overlay",
                column: "OverlayID");

            migrationBuilder.AddForeignKey(
                name: "FK_Overlay_Templates_TemplateID",
                table: "Overlay",
                column: "TemplateID",
                principalTable: "Templates",
                principalColumn: "TemplateID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameTable(
                name: "Overlays",
                newName: "Overlay");
        }
    }
}

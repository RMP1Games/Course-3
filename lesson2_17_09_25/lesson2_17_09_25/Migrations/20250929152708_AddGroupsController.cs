using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lesson2_17_09_25.Migrations
{
    /// <inheritdoc />
    public partial class AddGroupsController : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Directions_DirectionId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_DirectionId",
                table: "Groups");

            migrationBuilder.AddColumn<int>(
                name: "DescriptionId",
                table: "Groups",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_DescriptionId",
                table: "Groups",
                column: "DescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Directions_DescriptionId",
                table: "Groups",
                column: "DescriptionId",
                principalTable: "Directions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Directions_DescriptionId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_DescriptionId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "DescriptionId",
                table: "Groups");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_DirectionId",
                table: "Groups",
                column: "DirectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Directions_DirectionId",
                table: "Groups",
                column: "DirectionId",
                principalTable: "Directions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

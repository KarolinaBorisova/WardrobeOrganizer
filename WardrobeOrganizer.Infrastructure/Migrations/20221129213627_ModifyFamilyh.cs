using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeOrganizer.Infrastructure.Migrations
{
    public partial class ModifyFamilyh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Families_FamilyId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FamilyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FamilyId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Families",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Families_UserId",
                table: "Families",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Families_AspNetUsers_UserId",
                table: "Families",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Families_AspNetUsers_UserId",
                table: "Families");

            migrationBuilder.DropIndex(
                name: "IX_Families_UserId",
                table: "Families");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Families");

            migrationBuilder.AddColumn<int>(
                name: "FamilyId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FamilyId",
                table: "AspNetUsers",
                column: "FamilyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Families_FamilyId",
                table: "AspNetUsers",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id");
        }
    }
}

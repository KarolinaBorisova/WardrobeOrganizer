using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeOrganizer.Infrastructure.Migrations
{
    public partial class addFamilesDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Family_FamilyId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Family_FamilyId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Storages_Family_FamilyId",
                table: "Storages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Family",
                table: "Family");

            migrationBuilder.RenameTable(
                name: "Family",
                newName: "Families");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Families",
                table: "Families",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Families_FamilyId",
                table: "AspNetUsers",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Families_FamilyId",
                table: "Members",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Storages_Families_FamilyId",
                table: "Storages",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Families_FamilyId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Families_FamilyId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Storages_Families_FamilyId",
                table: "Storages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Families",
                table: "Families");

            migrationBuilder.RenameTable(
                name: "Families",
                newName: "Family");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Family",
                table: "Family",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Family_FamilyId",
                table: "AspNetUsers",
                column: "FamilyId",
                principalTable: "Family",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Family_FamilyId",
                table: "Members",
                column: "FamilyId",
                principalTable: "Family",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Storages_Family_FamilyId",
                table: "Storages",
                column: "FamilyId",
                principalTable: "Family",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeOrganizer.Infrastructure.Migrations
{
    public partial class modifyMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StorageId",
                table: "Members",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_StorageId",
                table: "Members",
                column: "StorageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Storages_StorageId",
                table: "Members",
                column: "StorageId",
                principalTable: "Storages",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Storages_StorageId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_StorageId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "StorageId",
                table: "Members");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeOrganizer.Infrastructure.Migrations
{
    public partial class ItemCategorynew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryShoes",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "CategoryOuterwear",
                table: "Outerwear");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Shoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Outerwear",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Accessories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeAge = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StorageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accessories_Storages_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2784e605-87de-4e3f-9dac-454830457740", "AQAAAAEAACcQAAAAEMYNKHRVBi3HIo4uEb7zS0eoKDgwAwKgdLlC73Hynp2SYPdcIYMwCW+ONfZ8zAjndw==", "682714d5-ee77-4b59-a941-a8c59fe247e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17b51276-a5b2-4ebf-a68a-8b307220cad3", "AQAAAAEAACcQAAAAEHsvd6vFavKf81dUO583Y6T7LhRAIPLRpNObmIhWEUE9BCd5kBF2/d+wUqti96RQjw==", "5c2ef82e-e6c8-427b-8d9d-53e08786956b" });

            migrationBuilder.CreateIndex(
                name: "IX_Accessories_StorageId",
                table: "Accessories",
                column: "StorageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accessories");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Outerwear");

            migrationBuilder.AddColumn<int>(
                name: "CategoryShoes",
                table: "Shoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryOuterwear",
                table: "Outerwear",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cbb01daa-38e9-4c7b-989d-e7f20022b6ee", "AQAAAAEAACcQAAAAEHUbMa/lRkXLfTjQoWyIiANKCOiwRC1tD8+sOg0lVJQOimXxulWsVn+GbiX7GUBbKw==", "ac640f7b-86ac-4b95-b30a-ad7e44dcb639" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf57b95c-1401-420e-84fa-01a70b8e0f27", "AQAAAAEAACcQAAAAEL0zOBhNm5Dxw8ErW8bgOh7iQFXXkZhF+N5QN/XWeUojDIV3wqLzLJAoYfcMb/dziQ==", "41d8a0f7-de92-4cb2-93ae-ff7819facbc5" });
        }
    }
}

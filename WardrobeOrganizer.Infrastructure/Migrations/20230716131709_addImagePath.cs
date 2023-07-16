using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeOrganizer.Infrastructure.Migrations
{
    public partial class addImagePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Shoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Outerwear",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Clothes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Accessories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4070bb9e-78f6-4a73-b170-714f59bbc6e5",
                column: "ConcurrencyStamp",
                value: "dac78ae8-21c7-46b3-90c2-63ad32858511");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "cc2f534e-f543-40d6-8527-ba7a89bf8366");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a00f86db-cb21-45e8-b0e7-ee2edf37a60b", "AQAAAAEAACcQAAAAEKa0NeA3hr+VKJBYBkVSTJa1NLUSw+rLNQIrZV+SN+G9RxZ1JojKesCC0wMl8UIjkA==", "20c30d5e-92af-4386-bce4-13ab5162f6d4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64431f24-0791-415e-b968-9d1b672bd6e0", "AQAAAAEAACcQAAAAEDhxEzBy7/GVjqaabA50dLqsv0h+rZo06jc9ZrWZw2R2eioc1nryPfjfcgfM0w37Fw==", "2467e9c0-52d6-49ca-9ca0-79b91cbfd829" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "446b0746-ebb6-472f-b0b6-7bfe3158a30b", "AQAAAAEAACcQAAAAEMF0NDVUXMIWQGSD4WVFG68PUBQZHfDteEc9wnUCDYgBKRMegJSTRrIxtoE3N2zm2Q==", "559b3882-fc82-48dc-b708-44df1eab1014" });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagePath",
                value: "/images/1.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Outerwear");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Accessories");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4070bb9e-78f6-4a73-b170-714f59bbc6e5",
                column: "ConcurrencyStamp",
                value: "ea088352-9851-4a7c-b851-0349cf706a0e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "ff3bbb4c-d28a-48ef-a987-7fe3eaa5ba63");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76ced86b-a280-4e14-9a06-aefcfc623ce9", "AQAAAAEAACcQAAAAECLtnrNkn6v5ty+lb+G/8A94Mssy+csKQk+Xo43ttbzJcqywIX+K5YFtDoP3uUzMJw==", "bc52da19-5b87-4e3c-a702-b72d18d5e90a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6fed0bc4-4a40-4e62-afd2-94c1f3947c35", "AQAAAAEAACcQAAAAEPcjZI580ZKWoiN9+vd6xmyS4vaYG3bYyLKvoukApw8Bmyrobh05TYntJzKeCVb7+g==", "3c3ad417-5317-40c9-bf44-99c91cb88eb2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "000ead7b-b117-47af-9be7-d480f4ae3645", "AQAAAAEAACcQAAAAEEkxsA6iNLUnd0PR7+JB7BIPtR9JGWUpJMrT7GlZTwYNz/qPLcRHbIDsEcvvK6QAVA==", "e52e2a73-5212-4e33-8c2d-d2a361e49533" });
        }
    }
}

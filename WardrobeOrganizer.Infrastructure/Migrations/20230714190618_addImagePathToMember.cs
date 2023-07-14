using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeOrganizer.Infrastructure.Migrations
{
    public partial class addImagePathToMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Members");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4070bb9e-78f6-4a73-b170-714f59bbc6e5",
                column: "ConcurrencyStamp",
                value: "ea4ae6d8-ad96-440d-8a27-1d0a6013b5cc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "7d64dd70-d311-4ca2-9fcd-dd3829f1b63c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2d6e7e6-eb9d-4d58-821e-a4fb0c6650eb", "AQAAAAEAACcQAAAAEGaSb2aeiZFSIkpK6ynJJEUEfJlxF8Vs4dBgfHgGs8sEAoHxqd/YeK5tQaxjGztutg==", "3fd177e4-a0ce-4d3f-8c5d-0681ddbc9fd6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa707234-6528-4962-bf0d-e424d9a551eb", "AQAAAAEAACcQAAAAELaR+9P5FlsM68SJjKNyevOFhwksS0SvyzkDwDBl8Re/yQyTXpVEAvhL34515SjMng==", "bd45922f-ae40-4158-9938-3973e15cc394" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49d6bc42-1bc6-4a73-b0f1-665163b1cae4", "AQAAAAEAACcQAAAAEOvlPAFxN1OUfc8GU2O01vugNuLnSS+epGJrTNuXKSZKmH+S6JfwVV3R1zCNIok2xQ==", "bd549a16-e022-4b52-83a9-6e37b3e1c6cb" });
        }
    }
}

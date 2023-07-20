using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeOrganizer.Infrastructure.Migrations
{
    public partial class removeImgUrlk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Outerwear");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Accessories");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4070bb9e-78f6-4a73-b170-714f59bbc6e5",
                column: "ConcurrencyStamp",
                value: "d036c8ce-4542-41d5-9588-ba6d21c9db36");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "17c136ac-d040-4d35-9f41-d27720b158e2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5dcce190-b931-4f9a-8386-0afb854b93d0", "AQAAAAEAACcQAAAAEBKXm1087rcBkcBsHSxFRfPeT4lex5uLZ631s0BcGyCa2BCqJjTqc6pB1bTYNpOlYw==", "fe11498d-4fad-4d18-ad5b-66cf4a3800e0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8954748d-7ef4-4f4c-977f-c85bfaba9b3c", "AQAAAAEAACcQAAAAEGfxapIAbZ6ufY5TE82C2JcDASDi7hAmPOtRyv65an7WI0qzuG7gsLm9u5ibbQpVdw==", "42289b25-3f35-4016-9c2c-a3b0423cf5a1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2f05fb6-e112-4283-bee3-b6240d5b375f", "AQAAAAEAACcQAAAAEMDbszO4vAXc0Wpqfw11StzkhUwiVOPR6QB60mnrwdD0lTtulZQtZG71cOT/DDFp+Q==", "7bc448ac-2365-4fe7-9eed-529a2bcfc45e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Shoes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Outerwear",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Clothes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Accessories",
                type: "nvarchar(max)",
                nullable: true);

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
                column: "ImgUrl",
                value: "http://unblast.com/wp-content/uploads/2019/04/Kids-T-Shirt-Mockup-1.jpg");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeOrganizer.Infrastructure.Migrations
{
    public partial class userIdToNotNullItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Shoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Outerwear",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Clothes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Accessories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4070bb9e-78f6-4a73-b170-714f59bbc6e5",
                column: "ConcurrencyStamp",
                value: "c2048b8e-ad2b-4899-ac4a-d96131640252");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "6cd9a3a6-f3af-4221-a4fa-55ab79c61574");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62ca2204-88a0-424f-a654-93807d995a26", "AQAAAAEAACcQAAAAELL7ZZDxORUz+jd0KxlbDKfESdOtgupHg+2+MvxNVlQmhvwTLrs7pAMMVMp14wJ9Nw==", "3179e719-d76d-4f8a-9803-27ee2fe38d01" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6cf90aba-018d-452d-a621-9c9b8643724c", "AQAAAAEAACcQAAAAEKOVsFT+cUiBBCX0NRSpHFZu18Yaxw1YG4v1xMn0kGW6d14Arwzrc7bixR1IRezIlw==", "f35b2298-ccee-4139-8d42-4425807b749a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee1ae12d-b00b-4956-b24c-b7a67ed6b32e", "AQAAAAEAACcQAAAAELXDhlNAWWg+etF/BeRQHUqX6iFYdiiUT1aogBnT8Mw0UU5lD7yNDgFknsUKUFn54w==", "d7381c98-19b7-4d9f-9423-fd3dad5290fc" });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Shoes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Outerwear",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Clothes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Accessories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4070bb9e-78f6-4a73-b170-714f59bbc6e5",
                column: "ConcurrencyStamp",
                value: "ec904059-11b2-448b-96d3-6b4342e77d7c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "09aa3641-bac9-43b8-9907-745e45f8927a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df54437f-afc3-4485-94d9-742c682d63fd", "AQAAAAEAACcQAAAAEFn+eTF4sTcKqAkEbgyd9ET0l9mWt1vb6VtuA/FIMzAFxMeRDmi4daTdRXceSRkgjQ==", "8dc4d9a0-bbc0-44e0-abaa-452799bb2d69" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9da0ace-11db-47de-968b-9468cbb2ce9c", "AQAAAAEAACcQAAAAEOEuVFUKxcDUede8uw+aitKmlO0D58k3r3U3X6BZ/zUpxslGwCR00qKFHsTrOmZtNQ==", "0aeedba1-400b-495c-b20e-070283a822c0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f76f5120-af9f-47d1-b475-42733b4c848e", "AQAAAAEAACcQAAAAEKbtEAW06ky2LMb8Nv6iRnTlq4mEkou1HtYeA+8MI01DBrCdCVvUBcWLd8kZ1+JW1A==", "a0f5e318-110d-4660-9f33-bc3a4cb96e69" });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: null);
        }
    }
}

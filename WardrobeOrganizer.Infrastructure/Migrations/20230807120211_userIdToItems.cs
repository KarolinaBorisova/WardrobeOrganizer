using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeOrganizer.Infrastructure.Migrations
{
    public partial class userIdToItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Shoes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Outerwear",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Clothes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Accessories",
                type: "nvarchar(max)",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Outerwear");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "UserId",
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
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeOrganizer.Infrastructure.Migrations
{
    public partial class ItemCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7845f74f-4a78-48f9-9f26-bfc75fd090af", "AQAAAAEAACcQAAAAEC3tHlG73Al2J6L/NJ6aJ3Y0g8N1pOHqq6pS9jRlQ68qaF0G7ICPXTVPDHG+FL0LYQ==", "0b299ad5-87b9-4716-b0d7-ffdc6e3c5aff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "183537db-583d-4dd2-af97-affd0c122491", "AQAAAAEAACcQAAAAEET96yGKORX8jPpcZQzvWtEaimnmw0l12G5dbsHRkscHdRsOMfiPZivnMwhBoFe5zg==", "65ddd88d-0a23-4894-9ff9-b5ed20b25a04" });
        }
    }
}

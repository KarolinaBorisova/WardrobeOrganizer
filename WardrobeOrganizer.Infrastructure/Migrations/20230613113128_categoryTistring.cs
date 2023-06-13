using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeOrganizer.Infrastructure.Migrations
{
    public partial class categoryTistring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Clothes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Category",
                value: "Tshirt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "Clothes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a81f0ec9-c273-42a9-a8e3-68ce1b0b5f33", "AQAAAAEAACcQAAAAEFW2BLdNmkTLFHOV9R/R7DxIgwA+X3/mBxtdXa7z4vP9zrpgnkRnt4nrncwfiP6xGA==", "fe98217f-2b13-4daf-8882-fe0302d26aa8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "124ae931-ec5f-46d5-a3ff-af0b7aed28fe", "AQAAAAEAACcQAAAAEIAwv1jFuInFGunPOUIztnDpepxtI4kKbA5MTA2vWc+f7XhINdVnb8ZyBtGf6CWfUQ==", "adebb2bc-061f-4d53-878f-8ed97fd9dd5a" });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Category",
                value: 0);
        }
    }
}

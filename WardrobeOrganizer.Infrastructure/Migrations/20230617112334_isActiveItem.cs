using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeOrganizer.Infrastructure.Migrations
{
    public partial class isActiveItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Shoes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Outerwear",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Clothes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Accessories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fcdbab5-59a3-4316-8b85-98dc040c4e93", "AQAAAAEAACcQAAAAEDlyNHPSWAU8Oa9gfglJr6UE3pRgvTlBoyWsW0sAnIZv8tqw1UejlpAOVVYFG9DGnA==", "a47cd2f5-8064-4a3d-b206-916f653edf89" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6dddcf5a-b04e-4839-957f-877f5d641c75", "AQAAAAEAACcQAAAAEPGznRxiG6CjUO6zYHdgSujq0Jod8zQytji5gUVSlev8B3U/Kio4txiIVNh0yTaYTg==", "6a556017-c5ca-4bc2-a8d6-f2ba50eb7c3e" });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Outerwear");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Accessories");

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
        }
    }
}

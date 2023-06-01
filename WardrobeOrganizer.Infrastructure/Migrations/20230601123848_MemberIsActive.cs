using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeOrganizer.Infrastructure.Migrations
{
    public partial class MemberIsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Members",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Members");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63a1887e-9064-4e6f-9aef-f56cd74c9f00", "AQAAAAEAACcQAAAAEB5UdJVaBVqp7qbR7G8Q0h2vFWdNA6du0J+tiTdVI07VXKVVigJF9MA17G4HR8wXlQ==", "7c766738-e7cb-43fb-bdc2-e68cbd08baf4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed169109-6fec-454d-a285-dfce96a3815b", "AQAAAAEAACcQAAAAEIJR1Je4CswYy2t1JrJy97A1QKSsubQaoLHvzYSwDw26S1ZfWCGhCRKmPJ5MZN/BPA==", "edd95a4a-7d23-482e-bbae-fdb276965e66" });
        }
    }
}

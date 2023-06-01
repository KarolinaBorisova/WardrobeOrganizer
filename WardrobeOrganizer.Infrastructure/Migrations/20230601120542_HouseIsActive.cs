using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeOrganizer.Infrastructure.Migrations
{
    public partial class HouseIsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Houses",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Houses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5fd91379-bf1c-43b2-b1d7-d3e926f65cae", "AQAAAAEAACcQAAAAEKudchI+AxVNsVoAIOC15Na/N2N2AeYyQhNF5qMo2+M2SdKzO82qV2eCoK2caiHMzQ==", "d2b8ba9d-ddd5-4f0f-a918-74d6c057bf8c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71f847b0-ba3b-4865-841b-6aba91098610", "AQAAAAEAACcQAAAAEDlKx9aoyjokfNEm4QffS1ArDIBKtLvRFqItnjanraPFj0Dr7GcX09OYm8scMgJPgA==", "c43547f7-cacc-49f1-a85e-dcfa70635f44" });
        }
    }
}

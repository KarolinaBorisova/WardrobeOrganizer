using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeOrganizer.Infrastructure.Migrations
{
    public partial class storageIsActiveAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Storages",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.UpdateData(
                table: "Storages",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Storages");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ba9bbd3-fd9c-4405-9bf2-52252f5c261d", "AQAAAAEAACcQAAAAENxu+NnbnxcjgFhyBusCYdhbvvLlwBl5m6VfaPLIDBy0do5IpKtXCoaqhI+ePw3nBw==", "f6f43d11-51fe-40cf-aece-d875b8dee6ee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f7dfdbe-fa39-4564-b317-52177cf56a45", "AQAAAAEAACcQAAAAEBkTm632yRu9+KPfmYFxnQK0Q0E1EzmdpDk2nWIkuOHwS5bl4pmDN/BBY9ZhUnLSQw==", "dfab966a-fbd5-446e-bdbb-b2717b1a05af" });
        }
    }
}

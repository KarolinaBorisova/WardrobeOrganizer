using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeOrganizer.Infrastructure.Migrations
{
    public partial class memberURlneLast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImgUrl",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30902058-3166-4f17-87a7-22fa0319dfd0", "AQAAAAEAACcQAAAAEO3PDy/hR6ZzYp27hFuC4W8RcKnCB8WktzgItwHF7h69Ghx5wEm8V16Lt2ZhZbWQ+w==", "440ac940-c9c1-42b1-9405-02fecea680ff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "905e7a4d-4915-4676-ad57-5abd6d08748d", "AQAAAAEAACcQAAAAEJKoRb2dMIgmpqcJdfo3tws/IK47bWnrWqBpLlAqprICOfzH8nEPkE07pn31eKfoCw==", "7e9ef23b-2e35-465b-8f42-2653ff12a5cd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImgUrl",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a158da7-6230-41cd-ac60-88acbd34a479", "AQAAAAEAACcQAAAAEH1a+fDk8XuznDReFmaTcC+GTdn0KveC6IJug68/ikMWhujVY7PLQFhOXfJ5yfbRyw==", "9245ca87-0b89-4f03-a9ff-fcf8f9761593" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "565393f0-d29f-48c9-add5-c1ed19672fff", "AQAAAAEAACcQAAAAEPtcdGTZHImTDN9YysmbWjbThGfHK6bjfsiq1xUh2Pc7N8ys4LmO2BaKAtTvBq8LLw==", "153e23af-d0c0-4be5-9d82-2c0662f0106b" });
        }
    }
}

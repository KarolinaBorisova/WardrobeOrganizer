using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeOrganizer.Infrastructure.Migrations
{
    public partial class memberURlne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b5fdd9b-47d5-4bd5-9a94-ea49baeaa675", "AQAAAAEAACcQAAAAEPs8HaB8iD1ONbzCbojXfnawo6jZ6InUCjfMeZWVm/wWecB5DSRMEc+y8GMkrk/NYA==", "515f7032-54b2-48ec-96f1-9959ad32f293" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f7a5333-fd31-4898-b8a5-0f9ad176b547", "AQAAAAEAACcQAAAAEGcqa+ONr3KYtiVGGE4Z9URv6Txn2HdsiZFa9eqLVMV5kbQm6dqAumz6z2XyhLv0NQ==", "df84ffe0-d1fb-4c30-b2c9-6cc00d33a292" });
        }
    }
}

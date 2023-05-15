using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeOrganizer.Infrastructure.Migrations
{
    public partial class memberURlnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "08b47f54-f9f7-48e4-97e1-5871d0f06859", "AQAAAAEAACcQAAAAEOe73w8UL8gb13fDBedWuGmS+BE7c3Ut72BaaEefEyqgNIGsvFYOLqDUxOxJ94o+Vw==", "52b0d7a1-51ef-4e38-9249-60de6a277848" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c46b2776-0194-4d6b-9050-8460c427f189", "AQAAAAEAACcQAAAAEJerqDQE6Jo+4I7c6ZC+saaVFaXpNUsiFTbflajqRbEBt134TN0aKAIykB9Q9UslWw==", "65973fe1-2467-4169-9b73-5047beccf40d" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeOrganizer.Infrastructure.Migrations
{
    public partial class newSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa3f87cd-39e8-4ccd-9c1d-78b28c57dfe6", "AQAAAAEAACcQAAAAEGy4x6tc6/3Aerj7rNRW6BHgQ2i/W+e3RbQIpJuRB1gB4/YBSWfeDMnGXP85xtbUiA==", "bdd48fa2-acee-4a1a-b447-f2bf546544fc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af4e0c2e-d8c6-4cc5-ad5e-e408536ff0f5", "AQAAAAEAACcQAAAAEA1OfiUfusIGfNI3h0PHqeblOXTftMYZ/xceVroY1sdHgpsjQsTZd/5sTgDgiWWwmA==", "ebbc1816-906f-4825-9d9a-daaafd44d065" });

            migrationBuilder.InsertData(
                table: "Families",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[] { 2, "Popovi", "2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7f018f9-1570-4371-a8ec-529d9adf1bf9", "AQAAAAEAACcQAAAAELiHTu6jkB02hEODwH87tGnd9ce7bm7ymJBViPo6HF0lRyhIw74iWXY8n92oL+zMaA==", "57f82e55-2ba2-4f61-94ba-be96cd53f88f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "110a39ab-470c-4cb9-ada5-bf09842d4679", "AQAAAAEAACcQAAAAEDqt1T7iWG9DHsZ66TInDArH42WYU7DLiVE29hYHVT4kU5yVWgMIey3KKQzGpHYZrA==", "a6a4e23d-ee9c-4c53-bed7-39cc0ce2337e" });
        }
    }
}

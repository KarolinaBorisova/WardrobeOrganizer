using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeOrganizer.Infrastructure.Migrations
{
    public partial class memberURl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Members");

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
        }
    }
}

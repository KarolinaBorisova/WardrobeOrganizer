using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeOrganizer.Infrastructure.Migrations
{
    public partial class addMemberToItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Shoes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Outerwear",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Clothes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Accessories",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0e9357b-c8ca-4073-9a8e-f6ca7e135a0d", "AQAAAAEAACcQAAAAEKfc5ipbok0S2G46PTQkQwo93VhII6E3cfRMhyqsQsa7KyBtK+RQVwloA0kWijFa7A==", "b36b1dcd-2b17-4df2-9cc9-e17261b39301" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d216d75f-cb6d-44ef-b6a2-8e79d29e8ce8", "AQAAAAEAACcQAAAAEHjLX+541zLq1KxscGmkYJCR0vi/C+aB0Rdy1N/opjkdClgE+rUOR/KzZRB/1ZfdTw==", "812f47b5-9e7e-4c7f-8740-80d62ac771e0" });

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_MemberId",
                table: "Shoes",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Outerwear_MemberId",
                table: "Outerwear",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_MemberId",
                table: "Clothes",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessories_MemberId",
                table: "Accessories",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accessories_Members_MemberId",
                table: "Accessories",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_Members_MemberId",
                table: "Clothes",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Outerwear_Members_MemberId",
                table: "Outerwear",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_Members_MemberId",
                table: "Shoes",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accessories_Members_MemberId",
                table: "Accessories");

            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_Members_MemberId",
                table: "Clothes");

            migrationBuilder.DropForeignKey(
                name: "FK_Outerwear_Members_MemberId",
                table: "Outerwear");

            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Members_MemberId",
                table: "Shoes");

            migrationBuilder.DropIndex(
                name: "IX_Shoes_MemberId",
                table: "Shoes");

            migrationBuilder.DropIndex(
                name: "IX_Outerwear_MemberId",
                table: "Outerwear");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_MemberId",
                table: "Clothes");

            migrationBuilder.DropIndex(
                name: "IX_Accessories_MemberId",
                table: "Accessories");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Outerwear");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Accessories");

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
        }
    }
}

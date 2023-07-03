using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeOrganizer.Infrastructure.Migrations
{
    public partial class addUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "fd60f4b4-5cda-48e7-b9ed-820cfdcf5408");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4070bb9e-78f6-4a73-b170-714f59bbc6e5", "ad552691-d8cd-4204-a6c5-8cb2e03bf44a", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31111222-9350-44c6-b10f-bfe618df63e1", "AQAAAAEAACcQAAAAEEL+lDiT0A5Eo12lTen48Z3icKzQ2QKu/3B3OPCKWmiEBd4MDAf2ggUfyuE/8TvDjA==", "9d489497-b64f-441f-9b43-72f2bd64bcab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34f29c5f-5f7f-45f7-8e60-d06c74503b21", "AQAAAAEAACcQAAAAENfwLJ65aIxKAnsbx/ZLgmy54YL1nt50ysBfZqKOMuNNWgRQKUmhZhyNPyfHlHL5DA==", "f874f757-547c-4876-a2c5-29a8dd70604b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "083fe889-8ff9-42bf-a8a0-27926f35f260", "AQAAAAEAACcQAAAAEI32mA47QjJbnLqX02Hlzy2cpCMheLANQnVcalfZbRbS3UUBxBdlJGOkOpQbaqBz4A==", "efa8565f-f70e-41b1-acf2-6baa3382084e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4070bb9e-78f6-4a73-b170-714f59bbc6e5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "ba0b2875-b71b-4739-abb4-d59e042a6302");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "004309b1-3abd-4add-b11b-d988736bb916", "AQAAAAEAACcQAAAAEJUVccDj/E7IkRUL5d/jtQ8B2k9XjU05dSGKKeeKk4NXSF30zZlKOAulr19KNkOV2Q==", "ccb0f53e-5488-40d9-80d2-14c946b76c9f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f3fc53d-8982-43fc-a7fc-2aef7b56b584", "AQAAAAEAACcQAAAAEAdN29lthQdi9yrZawmQLVcyHxXclkjgc1k9RiwczUSFgX0SAMvnVLQ/KljXbE7t2Q==", "4bd3dbff-371e-4195-bc3c-4826d130ac9e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0a292d8-2994-4365-bed5-44c68f6a93b8", "AQAAAAEAACcQAAAAEIG9RID+ldbvlo6s0axc2EZxyQNboxgaq4mntWIUvZSkmt3OKonMmFbKayIY7tBBvg==", "41b39f5a-e192-4d2b-8fb1-e944e7cbdf82" });
        }
    }
}

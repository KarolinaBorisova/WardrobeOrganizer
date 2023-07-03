using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeOrganizer.Infrastructure.Migrations
{
    public partial class addRolesToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4070bb9e-78f6-4a73-b170-714f59bbc6e5",
                column: "ConcurrencyStamp",
                value: "94d476bc-8cc9-4aad-88e4-10f974182a9b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "db08b25f-7ff4-4d12-94ad-123f78999191");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "4070bb9e-78f6-4a73-b170-714f59bbc6e5", "1" },
                    { "4070bb9e-78f6-4a73-b170-714f59bbc6e5", "2" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8bb2cf9-b94a-4d4d-8110-558b55a352e7", "AQAAAAEAACcQAAAAELG1Oq75KQbxHLwFFwBrj2VIjrT9ZiUY4N/cZNZ0U466reUP2kyGdBzw2ZPqdopXKA==", "c2086a02-34f5-490e-baee-7278d8edcd13" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0600df9-bfc2-4ac2-af80-797fb5203273", "AQAAAAEAACcQAAAAEGRIEGUuL4FTVR9ytkvaEjj4NPh39Yq+dA7Qsuyx+B1j5wfNJsl4DUCPtfjDM2h/Rg==", "c53f8b36-6540-4499-ae3f-9f291e813b7a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "142bbb07-fb55-4b9f-96d8-63dc51ccb9fb", "AQAAAAEAACcQAAAAEHIpaXTq8NB1/aD8ixfGcqQeysaHI518H718hTixprTwf3JbXBZyZPOC7ZpbIFu3Zg==", "c880eae9-3400-4272-8e12-c47d23cbbe70" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4070bb9e-78f6-4a73-b170-714f59bbc6e5", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4070bb9e-78f6-4a73-b170-714f59bbc6e5", "2" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4070bb9e-78f6-4a73-b170-714f59bbc6e5",
                column: "ConcurrencyStamp",
                value: "ad552691-d8cd-4204-a6c5-8cb2e03bf44a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "fd60f4b4-5cda-48e7-b9ed-820cfdcf5408");

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
    }
}

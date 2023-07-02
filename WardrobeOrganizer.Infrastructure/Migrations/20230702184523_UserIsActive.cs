using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeOrganizer.Infrastructure.Migrations
{
    public partial class UserIsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "004309b1-3abd-4add-b11b-d988736bb916", true, "AQAAAAEAACcQAAAAEJUVccDj/E7IkRUL5d/jtQ8B2k9XjU05dSGKKeeKk4NXSF30zZlKOAulr19KNkOV2Q==", "ccb0f53e-5488-40d9-80d2-14c946b76c9f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f3fc53d-8982-43fc-a7fc-2aef7b56b584", true, "AQAAAAEAACcQAAAAEAdN29lthQdi9yrZawmQLVcyHxXclkjgc1k9RiwczUSFgX0SAMvnVLQ/KljXbE7t2Q==", "4bd3dbff-371e-4195-bc3c-4826d130ac9e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0a292d8-2994-4365-bed5-44c68f6a93b8", true, "AQAAAAEAACcQAAAAEIG9RID+ldbvlo6s0axc2EZxyQNboxgaq4mntWIUvZSkmt3OKonMmFbKayIY7tBBvg==", "41b39f5a-e192-4d2b-8fb1-e944e7cbdf82" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "7cd4f039-23c2-4d3a-a4e7-60943c6a8593");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6673648-0bcc-42b6-a566-0244dbda143b", "AQAAAAEAACcQAAAAEMisTu+b2Ij/aGSfkuRMWfnb41zAOk4YsxRKZ8bwKlwMtbzrrPKB6vLf0Ef/QZ1zFQ==", "0e7bcd80-2ded-4657-95fd-8a7c93345924" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac2464fa-5684-4107-95b9-e82b115bc792", "AQAAAAEAACcQAAAAEAMcZAmxN0IRv08KT7ldkuQ18vB77N4pmNtltFp3SLFnoGVtMmnB66BeqWcnPTs4YQ==", "ce94bb1a-27ab-4cd9-822b-14efd7b329f0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6ede1be-dbe0-418f-9c28-3a5c8dd2a0e5", "AQAAAAEAACcQAAAAEJm0Zj16R09AZuTeqywtTSK+Qol20bh+g86BVjfO9LXA6hzseX4TrAL+vq+jG6ah6w==", "dc802f6f-16be-41e2-beec-9c1a3cf2a0de" });
        }
    }
}

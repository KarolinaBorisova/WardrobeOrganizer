using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeOrganizer.Infrastructure.Migrations
{
    public partial class addRolesWITHuSERaDMIN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "a6673648-0bcc-42b6-a566-0244dbda143b", "ADMIN@ABV.BG", "ADMIN@ABV.BG", "AQAAAAEAACcQAAAAEMisTu+b2Ij/aGSfkuRMWfnb41zAOk4YsxRKZ8bwKlwMtbzrrPKB6vLf0Ef/QZ1zFQ==", "0e7bcd80-2ded-4657-95fd-8a7c93345924", "admin@abv.bg" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "d8bf772b-f807-488f-8315-c8e4c0578b01");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "5a683b18-62bc-47a7-85e1-21ea2654c80b", "ADMIN@ADMIN.COM", "MASTERADMIN", "AQAAAAEAACcQAAAAEO3stb69TKjHZqzVC1jKeAhyYJqM7G1fzveYndUHyzZADAoCgznzIZwiLAZs6vxO5g==", "fdb93094-6583-455b-a0ba-cf79eae4e66b", "masteradmin" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3df3841b-9c90-4e71-83bc-5a0f0e619f28", "AQAAAAEAACcQAAAAEGyvAaeJXKFDuxbcd6tSmtk29Cxf8af+GqBIvoaxF11e2kjqFlCnb95h3pnFfPOk3w==", "5ec935bb-10c0-4b86-a65f-f1c6399ee442" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a5ebe5b-88e1-4cb1-8aba-0dec5e33aa2f", "AQAAAAEAACcQAAAAEI11a7P7GWYl2u4URcaT7kTX9X3o1/1IhcPLK2+Tkv1ZP3iZRwU5tEEPPyKO0KxW/g==", "327b73a3-a092-4edf-b2e5-df8992380d36" });
        }
    }
}

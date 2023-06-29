using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeOrganizer.Infrastructure.Migrations
{
    public partial class addRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", "d8bf772b-f807-488f-8315-c8e4c0578b01", "Administrator", "Administrator" });

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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FamilyId", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0", 0, "5a683b18-62bc-47a7-85e1-21ea2654c80b", "admin@abv.bg", false, null, "Master", "Admin", false, null, "ADMIN@ADMIN.COM", "MASTERADMIN", "AQAAAAEAACcQAAAAEO3stb69TKjHZqzVC1jKeAhyYJqM7G1fzveYndUHyzZADAoCgznzIZwiLAZs6vxO5g==", null, false, "fdb93094-6583-455b-a0ba-cf79eae4e66b", false, "masteradmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", "0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", "0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c693dbe0-ba3d-4ce7-8f35-f2ef9f274293", "AQAAAAEAACcQAAAAEEjZbIVWQK55CsbywV9HJEQMlXMGXKNOd4urTRe6CrybDLC4ruQcsI1qttx2X12qsg==", "063cb7b9-4a8b-4283-9921-c1239e5f1798" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7b90bdc-412c-4257-899a-55257798e024", "AQAAAAEAACcQAAAAEGe+F99+UrhwZ3ImpXOquBA5/uWHOq219cCfcwneIjjdypx4EA0IMkdifBnYd5Qh6w==", "c78b6ab5-4abb-4597-8325-873672e4241c" });
        }
    }
}

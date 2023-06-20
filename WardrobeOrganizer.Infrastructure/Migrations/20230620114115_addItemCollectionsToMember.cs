using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeOrganizer.Infrastructure.Migrations
{
    public partial class addItemCollectionsToMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}

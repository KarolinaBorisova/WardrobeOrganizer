using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeOrganizer.Infrastructure.Migrations
{
    public partial class modifyUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ClothesSize",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FootLengthCm",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ShoeSizeEu",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserHeight",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                table: "Members",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ClothesSize",
                table: "Members",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Members",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FootLengthCm",
                table: "Members",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Members",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Members",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ShoeSizeEu",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserHeight",
                table: "Members",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "ClothesSize",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "FootLengthCm",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "ShoeSizeEu",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "UserHeight",
                table: "Members");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ClothesSize",
                table: "AspNetUsers",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FootLengthCm",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ShoeSizeEu",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserHeight",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }
    }
}

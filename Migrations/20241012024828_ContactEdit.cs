using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Palmart.Migrations
{
    /// <inheritdoc />
    public partial class ContactEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Contact",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Contact",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2024, 10, 12, 5, 48, 27, 245, DateTimeKind.Local).AddTicks(9232));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "Contact");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2024, 10, 12, 5, 34, 6, 475, DateTimeKind.Local).AddTicks(8259));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeCrudTeste.Migrations
{
    /// <inheritdoc />
    public partial class testeIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesLead",
                table: "SalesLead");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "SalesLead");

            migrationBuilder.RenameTable(
                name: "SalesLead",
                newName: "SalesEntity");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "SalesEntity",
                newName: "Source");

            migrationBuilder.RenameColumn(
                name: "ConfirmPassword",
                table: "SalesEntity",
                newName: "Mobile");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesEntity",
                table: "SalesEntity",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesEntity",
                table: "SalesEntity");

            migrationBuilder.RenameTable(
                name: "SalesEntity",
                newName: "SalesLead");

            migrationBuilder.RenameColumn(
                name: "Source",
                table: "SalesLead",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Mobile",
                table: "SalesLead",
                newName: "ConfirmPassword");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "SalesLead",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesLead",
                table: "SalesLead",
                column: "Id");
        }
    }
}

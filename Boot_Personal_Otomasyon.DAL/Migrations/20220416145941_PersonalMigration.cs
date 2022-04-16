using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Boots_Personal_Otomasyon.DAL.Migrations
{
    public partial class PersonalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserAccountId",
                table: "UserAccount",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IndetifierNumber",
                table: "Personal",
                newName: "IdentifierNumber");

            migrationBuilder.RenameColumn(
                name: "PersonalId",
                table: "Personal",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Department",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Department",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedUserId",
                table: "Department",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecordededUserId",
                table: "Department",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RecourDate",
                table: "Department",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "ModifiedUserId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "RecordededUserId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "RecourDate",
                table: "Department");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserAccount",
                newName: "UserAccountId");

            migrationBuilder.RenameColumn(
                name: "IdentifierNumber",
                table: "Personal",
                newName: "IndetifierNumber");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Personal",
                newName: "PersonalId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Department",
                newName: "DepartmentId");
        }
    }
}

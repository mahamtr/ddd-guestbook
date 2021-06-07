using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class addingIMAGEURLDateSex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Usuarios",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "Image_URL",
                table: "Usuarios",
                maxLength: 4096,
                nullable: false,
                defaultValue: "https://www.gravatar.com/avatar/205e460b479e2e5b48aec07710c08d50?s=400");

            migrationBuilder.AddColumn<string>(
                name: "Sexo",
                table: "Usuarios",
                nullable: false,
                defaultValue: "Femenino");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Image_URL",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Usuarios");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class PropuestaStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Monto",
                table: "Propuestas",
                type: "decimal(13,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Propuestas",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Propuestas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "Propuestas",
                nullable: false,
                defaultValueSql: "getdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Propuestas");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Propuestas");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Propuestas");

            migrationBuilder.AlterColumn<decimal>(
                name: "Monto",
                table: "Propuestas",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(13,4)");
        }
    }
}

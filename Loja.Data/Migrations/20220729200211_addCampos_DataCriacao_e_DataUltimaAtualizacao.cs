using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Loja.Data.Migrations
{
    public partial class addCampos_DataCriacao_e_DataUltimaAtualizacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeCriacao",
                table: "Clientes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaAtualizacao",
                table: "Clientes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDeCriacao",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "UltimaAtualizacao",
                table: "Clientes");
        }
    }
}

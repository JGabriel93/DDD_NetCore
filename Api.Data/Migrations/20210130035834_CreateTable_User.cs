using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class CreateTable_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_USER",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    dt_update = table.Column<DateTime>(nullable: true),
                    dt_create = table.Column<DateTime>(nullable: false),
                    nm_name = table.Column<string>(maxLength: 60, nullable: false),
                    ds_cpf = table.Column<string>(maxLength: 11, nullable: false),
                    ds_email = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USER", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_USER_ds_cpf",
                table: "TB_USER",
                column: "ds_cpf",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_USER");
        }
    }
}

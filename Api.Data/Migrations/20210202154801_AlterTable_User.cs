using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AlterTable_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ds_password",
                table: "TB_USER",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "TB_USER",
                columns: new[] { "Id", "ds_cpf", "dt_create", "ds_email", "nm_name", "ds_password", "dt_update" },
                values: new object[] { new Guid("3362d96b-e3ff-4cc8-85b5-da08a612e62f"), "01194433502", new DateTime(2021, 2, 2, 15, 48, 1, 548, DateTimeKind.Utc).AddTicks(2866), "admin@mail.com", "admin", "$2b$10$hlsO6RvjxCqgz4gTBMtJVulFpzuSeHdC4usIrZV6ZOQHtPXPcP3nS", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TB_USER",
                keyColumn: "Id",
                keyValue: new Guid("3362d96b-e3ff-4cc8-85b5-da08a612e62f"));

            migrationBuilder.DropColumn(
                name: "ds_password",
                table: "TB_USER");
        }
    }
}

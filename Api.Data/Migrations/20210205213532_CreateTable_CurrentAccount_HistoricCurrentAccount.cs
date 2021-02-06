using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class CreateTable_CurrentAccount_HistoricCurrentAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CURRENT_ACCOUNT",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    dt_update = table.Column<DateTime>(nullable: true),
                    dt_create = table.Column<DateTime>(nullable: false),
                    vl_balance = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    id_user = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CURRENT_ACCOUNT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_CURRENT_ACCOUNT_TB_USER_id_user",
                        column: x => x.id_user,
                        principalTable: "TB_USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_HISTORIC_CURRENT_ACCOUNT",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    dt_update = table.Column<DateTime>(nullable: true),
                    dt_create = table.Column<DateTime>(nullable: false),
                    ds_movement = table.Column<string>(maxLength: 1, nullable: false),
                    vl_amount_moved = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    id_current_account = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_HISTORIC_CURRENT_ACCOUNT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_HISTORIC_CURRENT_ACCOUNT_TB_CURRENT_ACCOUNT_id_current_ac~",
                        column: x => x.id_current_account,
                        principalTable: "TB_CURRENT_ACCOUNT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "TB_USER",
                keyColumn: "Id",
                keyValue: new Guid("3362d96b-e3ff-4cc8-85b5-da08a612e62f"),
                columns: new[] { "dt_create", "nm_name", "ds_password" },
                values: new object[] { new DateTime(2021, 2, 5, 21, 35, 31, 667, DateTimeKind.Utc).AddTicks(5085), "João", "$2b$10$I2BAk/kfX/dVWnvwv.1nNuS06F3LfiX6yzmpZPjSgZcmnQerCWwWK" });

            migrationBuilder.InsertData(
                table: "TB_USER",
                columns: new[] { "Id", "ds_cpf", "dt_create", "ds_email", "nm_name", "ds_password", "dt_update" },
                values: new object[] { new Guid("b171c698-abec-418c-9357-80d0b9199d1c"), "26687020544", new DateTime(2021, 2, 5, 21, 35, 31, 667, DateTimeKind.Utc).AddTicks(5085), "jose@mail.com", "José", "$2b$10$wvTGYJlEzDCUYg87ecaoYeURs2D2PwB5WOj0ytsdPoJV8lX/wjOhi", null });

            migrationBuilder.CreateIndex(
                name: "IX_TB_CURRENT_ACCOUNT_id_user",
                table: "TB_CURRENT_ACCOUNT",
                column: "id_user",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_HISTORIC_CURRENT_ACCOUNT_id_current_account",
                table: "TB_HISTORIC_CURRENT_ACCOUNT",
                column: "id_current_account");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_HISTORIC_CURRENT_ACCOUNT");

            migrationBuilder.DropTable(
                name: "TB_CURRENT_ACCOUNT");

            migrationBuilder.DeleteData(
                table: "TB_USER",
                keyColumn: "Id",
                keyValue: new Guid("b171c698-abec-418c-9357-80d0b9199d1c"));

            migrationBuilder.UpdateData(
                table: "TB_USER",
                keyColumn: "Id",
                keyValue: new Guid("3362d96b-e3ff-4cc8-85b5-da08a612e62f"),
                columns: new[] { "dt_create", "nm_name", "ds_password" },
                values: new object[] { new DateTime(2021, 2, 2, 15, 48, 1, 548, DateTimeKind.Utc).AddTicks(2866), "admin", "$2b$10$hlsO6RvjxCqgz4gTBMtJVulFpzuSeHdC4usIrZV6ZOQHtPXPcP3nS" });
        }
    }
}

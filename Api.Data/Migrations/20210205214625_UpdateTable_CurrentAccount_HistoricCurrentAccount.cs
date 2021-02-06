using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class UpdateTable_CurrentAccount_HistoricCurrentAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TB_CURRENT_ACCOUNT",
                columns: new[] { "Id", "vl_balance", "dt_create", "dt_update", "id_user" },
                values: new object[,]
                {
                    { new Guid("f7f8325d-7dab-425b-a59d-2e25f5354c62"), 1000m, new DateTime(2021, 2, 5, 21, 46, 24, 361, DateTimeKind.Utc).AddTicks(4373), new DateTime(2021, 2, 5, 21, 46, 24, 361, DateTimeKind.Utc).AddTicks(4373), new Guid("3362d96b-e3ff-4cc8-85b5-da08a612e62f") },
                    { new Guid("cee743f5-513c-4464-98d2-6e8dfaba1038"), 0m, new DateTime(2021, 2, 5, 21, 46, 24, 361, DateTimeKind.Utc).AddTicks(4373), new DateTime(2021, 2, 5, 21, 46, 24, 361, DateTimeKind.Utc).AddTicks(4373), new Guid("b171c698-abec-418c-9357-80d0b9199d1c") }
                });

            migrationBuilder.UpdateData(
                table: "TB_USER",
                keyColumn: "Id",
                keyValue: new Guid("3362d96b-e3ff-4cc8-85b5-da08a612e62f"),
                columns: new[] { "dt_create", "ds_password" },
                values: new object[] { new DateTime(2021, 2, 5, 21, 46, 24, 120, DateTimeKind.Utc).AddTicks(9436), "$2b$10$/UzCXCmRbxmkE3rXwn8r1efR/Gh40gM72zHNvzvObq3HLwVjKySeS" });

            migrationBuilder.UpdateData(
                table: "TB_USER",
                keyColumn: "Id",
                keyValue: new Guid("b171c698-abec-418c-9357-80d0b9199d1c"),
                columns: new[] { "dt_create", "ds_password" },
                values: new object[] { new DateTime(2021, 2, 5, 21, 46, 24, 120, DateTimeKind.Utc).AddTicks(9436), "$2b$10$2BnbmaBHM7/Mh1k8iUWE1eV8BVzQwvnFVQeqXEwPOAiMZirt/llvW" });

            migrationBuilder.InsertData(
                table: "TB_HISTORIC_CURRENT_ACCOUNT",
                columns: new[] { "Id", "vl_amount_moved", "dt_create", "id_current_account", "ds_movement", "dt_update" },
                values: new object[] { new Guid("a33f9455-ccb4-4b77-83ba-16dd3a7436a3"), 1000m, new DateTime(2021, 2, 5, 21, 46, 24, 361, DateTimeKind.Utc).AddTicks(4373), new Guid("f7f8325d-7dab-425b-a59d-2e25f5354c62"), "D", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TB_CURRENT_ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("cee743f5-513c-4464-98d2-6e8dfaba1038"));

            migrationBuilder.DeleteData(
                table: "TB_HISTORIC_CURRENT_ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("a33f9455-ccb4-4b77-83ba-16dd3a7436a3"));

            migrationBuilder.DeleteData(
                table: "TB_CURRENT_ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("f7f8325d-7dab-425b-a59d-2e25f5354c62"));

            migrationBuilder.UpdateData(
                table: "TB_USER",
                keyColumn: "Id",
                keyValue: new Guid("3362d96b-e3ff-4cc8-85b5-da08a612e62f"),
                columns: new[] { "dt_create", "ds_password" },
                values: new object[] { new DateTime(2021, 2, 5, 21, 35, 31, 667, DateTimeKind.Utc).AddTicks(5085), "$2b$10$I2BAk/kfX/dVWnvwv.1nNuS06F3LfiX6yzmpZPjSgZcmnQerCWwWK" });

            migrationBuilder.UpdateData(
                table: "TB_USER",
                keyColumn: "Id",
                keyValue: new Guid("b171c698-abec-418c-9357-80d0b9199d1c"),
                columns: new[] { "dt_create", "ds_password" },
                values: new object[] { new DateTime(2021, 2, 5, 21, 35, 31, 667, DateTimeKind.Utc).AddTicks(5085), "$2b$10$wvTGYJlEzDCUYg87ecaoYeURs2D2PwB5WOj0ytsdPoJV8lX/wjOhi" });
        }
    }
}

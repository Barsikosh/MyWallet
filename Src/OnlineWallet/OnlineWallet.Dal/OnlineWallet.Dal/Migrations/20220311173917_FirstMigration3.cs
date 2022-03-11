using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineWallet.Dal.Migrations
{
    public partial class FirstMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customer_UserName",
                table: "Customer",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customer_UserName",
                table: "Customer");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineWallet.Dal.Migrations
{
    public partial class FirstMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Wallet_WalletId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_WalletId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "WalletId",
                table: "Customer");

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_CustomerId",
                table: "Wallet",
                column: "CustomerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Wallet_Customer_CustomerId",
                table: "Wallet",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallet_Customer_CustomerId",
                table: "Wallet");

            migrationBuilder.DropIndex(
                name: "IX_Wallet_CustomerId",
                table: "Wallet");

            migrationBuilder.AddColumn<Guid>(
                name: "WalletId",
                table: "Customer",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Customer_WalletId",
                table: "Customer",
                column: "WalletId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Wallet_WalletId",
                table: "Customer",
                column: "WalletId",
                principalTable: "Wallet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

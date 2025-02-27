using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FashionStock.Migrations
{
    /// <inheritdoc />
    public partial class stockrecordtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "Users",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "StockRecords",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "StockRecords",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "RecordTypes",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "RecordTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "Products",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "Images",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Images",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "Categories",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Categories",
                newName: "Id");

            migrationBuilder.AlterColumn<long>(
                name: "RecordTypeId",
                table: "StockRecords",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "StockRecords",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_StockRecords_ProductId",
                table: "StockRecords",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StockRecords_RecordTypeId",
                table: "StockRecords",
                column: "RecordTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockRecords_Products_ProductId",
                table: "StockRecords",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockRecords_RecordTypes_RecordTypeId",
                table: "StockRecords",
                column: "RecordTypeId",
                principalTable: "RecordTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockRecords_Products_ProductId",
                table: "StockRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_StockRecords_RecordTypes_RecordTypeId",
                table: "StockRecords");

            migrationBuilder.DropIndex(
                name: "IX_StockRecords_ProductId",
                table: "StockRecords");

            migrationBuilder.DropIndex(
                name: "IX_StockRecords_RecordTypeId",
                table: "StockRecords");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Users",
                newName: "isDeleted");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "StockRecords",
                newName: "isDeleted");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StockRecords",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "RecordTypes",
                newName: "isDeleted");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "RecordTypes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Products",
                newName: "isDeleted");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Images",
                newName: "isDeleted");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Images",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Categories",
                newName: "isDeleted");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "id");

            migrationBuilder.AlterColumn<int>(
                name: "RecordTypeId",
                table: "StockRecords",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "StockRecords",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}

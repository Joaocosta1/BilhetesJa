using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class PrecisionAdjustmentsForNullableObjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Transfers",
                type: "timestamp(0)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProcessingDate",
                table: "Transfers",
                type: "timestamp(0)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CancellationDate",
                table: "Transfers",
                type: "timestamp(0)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Sales",
                type: "timestamp(0)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPayedTax",
                table: "Sales",
                type: "decimal(18, 2)",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Profit",
                table: "Sales",
                type: "decimal(18, 2)",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProcessingDate",
                table: "Sales",
                type: "timestamp(0)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CancellationDate",
                table: "Sales",
                type: "timestamp(0)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Receipts",
                type: "timestamp(0)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProcessingDate",
                table: "Receipts",
                type: "timestamp(0)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CancellationDate",
                table: "Receipts",
                type: "timestamp(0)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Products",
                type: "timestamp(0)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PurchasePrice",
                table: "Products",
                type: "decimal(18, 2)",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Events",
                type: "timestamp(0)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Transfers",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProcessingDate",
                table: "Transfers",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CancellationDate",
                table: "Transfers",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Sales",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "TotalPayedTax",
                table: "Sales",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Profit",
                table: "Sales",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProcessingDate",
                table: "Sales",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CancellationDate",
                table: "Sales",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Receipts",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProcessingDate",
                table: "Receipts",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CancellationDate",
                table: "Receipts",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Products",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PurchasePrice",
                table: "Products",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Events",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0)",
                oldNullable: true);
        }
    }
}

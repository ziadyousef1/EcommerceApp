using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcommerceApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f55e511-7b7a-4732-bf81-30cf9a181963");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b8c71ac-a5a4-47df-bb8e-3b6f6767b7fb");

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("0dbf9724-5aee-40a8-9fcf-e4147851d34d"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("49718bb3-68d9-4514-b674-aa4e460e410d"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("996a2406-4a87-4c2a-b455-5b3681769248"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "825fad09-9bcf-4f36-b622-15d7696537ef", null, "User", "USER" },
                    { "90a76b11-9eac-4451-9617-05c1a4d6b453", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("20de0dad-59b0-4aaa-bbc8-edf91cd403e4"), "Credit Card" },
                    { new Guid("96d22a5b-9af5-4a3c-a105-e4b93bdad634"), "PayPal" },
                    { new Guid("ae96cac1-3c12-4f38-aac0-63ba26b6b88c"), "Cash" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "825fad09-9bcf-4f36-b622-15d7696537ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90a76b11-9eac-4451-9617-05c1a4d6b453");

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("20de0dad-59b0-4aaa-bbc8-edf91cd403e4"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("96d22a5b-9af5-4a3c-a105-e4b93bdad634"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("ae96cac1-3c12-4f38-aac0-63ba26b6b88c"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f55e511-7b7a-4732-bf81-30cf9a181963", null, "Admin", "ADMIN" },
                    { "2b8c71ac-a5a4-47df-bb8e-3b6f6767b7fb", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0dbf9724-5aee-40a8-9fcf-e4147851d34d"), "PayPal" },
                    { new Guid("49718bb3-68d9-4514-b674-aa4e460e410d"), "Credit Card" },
                    { new Guid("996a2406-4a87-4c2a-b455-5b3681769248"), "Cash" }
                });
        }
    }
}

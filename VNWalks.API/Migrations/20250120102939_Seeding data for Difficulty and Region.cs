using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VNWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataforDifficultyandRegion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4267ac23-8ac0-4d8a-9a8c-50abd5e1b57b"), "Medium" },
                    { new Guid("752498e4-2f26-43a0-a7ab-bb80786b656b"), "Easy" },
                    { new Guid("ff05d366-448d-4a90-8a63-4974055a1daf"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("3018c7a0-5dbb-49be-a722-f076d6987492"), "VT", "Vũng Tàu", "https://example.com/images/vung-tau.jpg" },
                    { new Guid("95e8a2c6-c877-4d0b-9ecb-5d8a32106e24"), "DL", "Đà Lạt", "https://example.com/images/da-lat.jpg" },
                    { new Guid("afce7fa8-e4fa-4780-84bd-f5dbfcd28c45"), "QN", "Quảng Ninh", "https://example.com/images/quang-ninh.jpg" },
                    { new Guid("b4036a50-eb15-4ffd-832c-f32f1aa5a1d5"), "DN", "Đà Nẵng", "https://example.com/images/da-nang.jpg" },
                    { new Guid("b7211821-39ce-4f38-8c7c-26cee55c3f98"), "HCM", "Hồ Chí Minh", "https://example.com/images/ho-chi-minh.jpg" },
                    { new Guid("c5cf1405-b511-4f93-8693-7bc7dd4ff5ee"), "HP", "Hải Phòng", "https://example.com/images/hai-phong.jpg" },
                    { new Guid("d5ee681a-5fd0-4d27-997b-635c62d615d8"), "HN", "Hà Nội", "https://example.com/images/ha-noi.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("4267ac23-8ac0-4d8a-9a8c-50abd5e1b57b"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("752498e4-2f26-43a0-a7ab-bb80786b656b"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("ff05d366-448d-4a90-8a63-4974055a1daf"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("3018c7a0-5dbb-49be-a722-f076d6987492"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("95e8a2c6-c877-4d0b-9ecb-5d8a32106e24"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("afce7fa8-e4fa-4780-84bd-f5dbfcd28c45"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b4036a50-eb15-4ffd-832c-f32f1aa5a1d5"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b7211821-39ce-4f38-8c7c-26cee55c3f98"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c5cf1405-b511-4f93-8693-7bc7dd4ff5ee"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d5ee681a-5fd0-4d27-997b-635c62d615d8"));
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Academy2018_.NET_Homework5.Infrastructure.Migrations
{
    public partial class AddedSomeAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Airplanes_AirplaneTypes_TypeId",
                table: "Airplanes");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Airplanes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Airplanes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Airplanes_AirplaneTypes_TypeId",
                table: "Airplanes",
                column: "TypeId",
                principalTable: "AirplaneTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Airplanes_AirplaneTypes_TypeId",
                table: "Airplanes");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Airplanes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Airplanes",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Airplanes_AirplaneTypes_TypeId",
                table: "Airplanes",
                column: "TypeId",
                principalTable: "AirplaneTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoderCampsMentor.Migrations
{
    public partial class addImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "subCatImageUrl",
                table: "SubCategories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "catImageUrl",
                table: "Categories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "subCatImageUrl",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "catImageUrl",
                table: "Categories");
        }
    }
}

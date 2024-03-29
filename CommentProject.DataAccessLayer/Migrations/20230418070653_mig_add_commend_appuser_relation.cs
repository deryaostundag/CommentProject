﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommentProject.DataAccessLayer.Migrations
{
    public partial class mig_add_commend_appuser_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AppUserID",
                table: "Comments",
                column: "AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserID",
                table: "Comments",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AppUserID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Comments");
        }
    }
}

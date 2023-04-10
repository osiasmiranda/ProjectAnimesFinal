using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedeSocial.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeGuidOfAuthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_ProfileEntityId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ProfileEntityId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ProfileEntityId",
                table: "Posts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthOfDay",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ProfileEntityId",
                table: "Posts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthOfDay",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ProfileEntityId",
                table: "Posts",
                column: "ProfileEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_ProfileEntityId",
                table: "Posts",
                column: "ProfileEntityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

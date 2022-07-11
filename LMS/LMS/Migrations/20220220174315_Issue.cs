using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Migrations
{
    public partial class Issue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Issues_MemberId",
                table: "Issues");

            migrationBuilder.AddColumn<int>(
                name: "BookAuthorID",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Issues_MemberId",
                table: "Issues",
                column: "MemberId",
                unique: true,
                filter: "[MemberId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Issues_MemberId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "BookAuthorID",
                table: "Books");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_MemberId",
                table: "Issues",
                column: "MemberId");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Migrations
{
    public partial class Corrections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Issues_IssueId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Issues_IssueId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_IssueId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Issues_MemberId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Books_IssueId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IssueId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "BookAuthorID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IssueId",
                table: "Books");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_MemberId",
                table: "Issues",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Issues_MemberId",
                table: "Issues");

            migrationBuilder.AddColumn<int>(
                name: "IssueId",
                table: "Members",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookAuthorID",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IssueId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_IssueId",
                table: "Members",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_MemberId",
                table: "Issues",
                column: "MemberId",
                unique: true,
                filter: "[MemberId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Books_IssueId",
                table: "Books",
                column: "IssueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Issues_IssueId",
                table: "Books",
                column: "IssueId",
                principalTable: "Issues",
                principalColumn: "Issue ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Issues_IssueId",
                table: "Members",
                column: "IssueId",
                principalTable: "Issues",
                principalColumn: "Issue ID");
        }
    }
}

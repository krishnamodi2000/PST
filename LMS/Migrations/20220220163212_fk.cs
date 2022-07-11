using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Migrations
{
    public partial class fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Author_AuthorId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publication_PublicationId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "PublicationId",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IssueId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    IssueID = table.Column<int>(name: "Issue ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueDate = table.Column<DateTime>(name: "Issue Date", type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(name: "Return Date", type: "datetime2", nullable: false),
                    ReturnSatus = table.Column<bool>(name: "Return Satus", type: "bit", nullable: false),
                    BookId = table.Column<int>(name: "Book Id", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.IssueID);
                    table.ForeignKey(
                        name: "FK_Issues_Books_Book Id",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Book ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_IssueId",
                table: "Books",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_Book Id",
                table: "Issues",
                column: "Book Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Author_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Author ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Issues_IssueId",
                table: "Books",
                column: "IssueId",
                principalTable: "Issues",
                principalColumn: "Issue ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publication_PublicationId",
                table: "Books",
                column: "PublicationId",
                principalTable: "Publication",
                principalColumn: "Publication ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Author_AuthorId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Issues_IssueId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publication_PublicationId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Books_IssueId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IssueId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "PublicationId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Author_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Author ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publication_PublicationId",
                table: "Books",
                column: "PublicationId",
                principalTable: "Publication",
                principalColumn: "Publication ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

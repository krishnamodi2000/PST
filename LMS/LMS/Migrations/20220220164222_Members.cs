using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Migrations
{
    public partial class Members : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Issues",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Designations",
                columns: table => new
                {
                    DesignationID = table.Column<int>(name: "Designation ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignationTitle = table.Column<string>(name: "Designation Title", type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations", x => x.DesignationID);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberID = table.Column<int>(name: "Member ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberFirstName = table.Column<string>(name: "Member First Name", type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MemberSurname = table.Column<string>(name: "Member Surname", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MemberPhoneNumber = table.Column<string>(name: "Member Phone Number", type: "nvarchar(max)", nullable: true),
                    IssueId = table.Column<int>(type: "int", nullable: true),
                    MemberDesignationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberID);
                    table.ForeignKey(
                        name: "FK_Members_Designations_MemberDesignationId",
                        column: x => x.MemberDesignationId,
                        principalTable: "Designations",
                        principalColumn: "Designation ID");
                    table.ForeignKey(
                        name: "FK_Members_Issues_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issues",
                        principalColumn: "Issue ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Issues_MemberId",
                table: "Issues",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_IssueId",
                table: "Members",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_MemberDesignationId",
                table: "Members",
                column: "MemberDesignationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Members_MemberId",
                table: "Issues",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Member ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Members_MemberId",
                table: "Issues");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Designations");

            migrationBuilder.DropIndex(
                name: "IX_Issues_MemberId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Issues");
        }
    }
}

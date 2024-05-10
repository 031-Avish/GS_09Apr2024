using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestTrackerModelLibrary.Migrations
{
    public partial class feedbacks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestFeedbacks_Employees_FeedbackBy",
                table: "RequestFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestFeedbacks_RequestSolutions_SolutionId",
                table: "RequestFeedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestFeedbacks",
                table: "RequestFeedbacks");

            migrationBuilder.RenameTable(
                name: "RequestFeedbacks",
                newName: "SolutionFeedbacks");

            migrationBuilder.RenameIndex(
                name: "IX_RequestFeedbacks_SolutionId",
                table: "SolutionFeedbacks",
                newName: "IX_SolutionFeedbacks_SolutionId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestFeedbacks_FeedbackBy",
                table: "SolutionFeedbacks",
                newName: "IX_SolutionFeedbacks_FeedbackBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolutionFeedbacks",
                table: "SolutionFeedbacks",
                column: "FeedbackId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionFeedbacks_Employees_FeedbackBy",
                table: "SolutionFeedbacks",
                column: "FeedbackBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionFeedbacks_RequestSolutions_SolutionId",
                table: "SolutionFeedbacks",
                column: "SolutionId",
                principalTable: "RequestSolutions",
                principalColumn: "SolutionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolutionFeedbacks_Employees_FeedbackBy",
                table: "SolutionFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionFeedbacks_RequestSolutions_SolutionId",
                table: "SolutionFeedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolutionFeedbacks",
                table: "SolutionFeedbacks");

            migrationBuilder.RenameTable(
                name: "SolutionFeedbacks",
                newName: "RequestFeedbacks");

            migrationBuilder.RenameIndex(
                name: "IX_SolutionFeedbacks_SolutionId",
                table: "RequestFeedbacks",
                newName: "IX_RequestFeedbacks_SolutionId");

            migrationBuilder.RenameIndex(
                name: "IX_SolutionFeedbacks_FeedbackBy",
                table: "RequestFeedbacks",
                newName: "IX_RequestFeedbacks_FeedbackBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestFeedbacks",
                table: "RequestFeedbacks",
                column: "FeedbackId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestFeedbacks_Employees_FeedbackBy",
                table: "RequestFeedbacks",
                column: "FeedbackBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestFeedbacks_RequestSolutions_SolutionId",
                table: "RequestFeedbacks",
                column: "SolutionId",
                principalTable: "RequestSolutions",
                principalColumn: "SolutionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

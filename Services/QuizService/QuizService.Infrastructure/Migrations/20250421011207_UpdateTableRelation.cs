using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Quizzes_DifficultyId",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_QuizStatusId",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_TagId",
                table: "Quizzes");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_DifficultyId",
                table: "Quizzes",
                column: "DifficultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_QuizStatusId",
                table: "Quizzes",
                column: "QuizStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_TagId",
                table: "Quizzes",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Quizzes_DifficultyId",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_QuizStatusId",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_TagId",
                table: "Quizzes");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_DifficultyId",
                table: "Quizzes",
                column: "DifficultyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_QuizStatusId",
                table: "Quizzes",
                column: "QuizStatusId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_TagId",
                table: "Quizzes",
                column: "TagId",
                unique: true);
        }
    }
}

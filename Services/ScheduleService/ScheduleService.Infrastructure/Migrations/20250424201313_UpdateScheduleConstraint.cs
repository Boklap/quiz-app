using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScheduleService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateScheduleConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Schedules_StatusId",
                table: "Schedules");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_StatusId",
                table: "Schedules",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Schedules_StatusId",
                table: "Schedules");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_StatusId",
                table: "Schedules",
                column: "StatusId",
                unique: true);
        }
    }
}

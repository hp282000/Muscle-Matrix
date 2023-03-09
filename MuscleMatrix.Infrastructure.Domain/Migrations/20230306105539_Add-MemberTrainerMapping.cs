using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuscleMatrix.Infrastructure.Domain.Migrations
{
    public partial class AddMemberTrainerMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_memberTrainerMappings_MemberId",
                table: "memberTrainerMappings",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_memberTrainerMappings_TrainerId",
                table: "memberTrainerMappings",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_memberTrainerMappings_Members_MemberId",
                table: "memberTrainerMappings",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_memberTrainerMappings_Trainers_TrainerId",
                table: "memberTrainerMappings",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_memberTrainerMappings_Members_MemberId",
                table: "memberTrainerMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_memberTrainerMappings_Trainers_TrainerId",
                table: "memberTrainerMappings");

            migrationBuilder.DropIndex(
                name: "IX_memberTrainerMappings_MemberId",
                table: "memberTrainerMappings");

            migrationBuilder.DropIndex(
                name: "IX_memberTrainerMappings_TrainerId",
                table: "memberTrainerMappings");
        }
    }
}

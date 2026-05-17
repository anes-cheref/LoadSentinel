using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoadSentinel.Migrations
{
    /// <inheritdoc />
    public partial class ChangedScenarioName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestRuns_Scenarios_ScenarioId",
                table: "TestRuns");

            migrationBuilder.DropTable(
                name: "Scenarios");

            migrationBuilder.CreateTable(
                name: "Scenario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThreshholdMaxResponseTimeMs = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenario", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TestRuns_Scenario_ScenarioId",
                table: "TestRuns",
                column: "ScenarioId",
                principalTable: "Scenario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestRuns_Scenario_ScenarioId",
                table: "TestRuns");

            migrationBuilder.DropTable(
                name: "Scenario");

            migrationBuilder.CreateTable(
                name: "Scenarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThreshholdMaxResponseTimeMs = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenarios", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TestRuns_Scenarios_ScenarioId",
                table: "TestRuns",
                column: "ScenarioId",
                principalTable: "Scenarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

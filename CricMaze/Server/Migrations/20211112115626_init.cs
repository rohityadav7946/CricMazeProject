using Microsoft.EntityFrameworkCore.Migrations;

namespace CricMaze.Server.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Matches = table.Column<int>(type: "int", nullable: false),
                    Runs = table.Column<int>(type: "int", nullable: false),
                    Highest = table.Column<int>(type: "int", nullable: false),
                    Wickets = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "TeamName" },
                values: new object[,]
                {
                    { 1, "RCB" },
                    { 2, "Mumbai Indians" },
                    { 3, "Rajasthan Royals" },
                    { 4, "SRH" },
                    { 5, "CSK" },
                    { 6, "Delhi Capitals" },
                    { 7, "Punjab Kings" },
                    { 8, "KKR" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "Country", "FirstName", "Highest", "LastName", "Matches", "Role", "Runs", "TeamId", "Wickets" },
                values: new object[,]
                {
                    { 1, "India", "Virat", 183, "Kohli", 254, 0, 12123, 1, 15 },
                    { 2, "India", "Jasprit", 26, "Bumrah", 90, 1, 545, 2, 165 },
                    { 3, "England", "Ben", 139, "Stokes", 152, 2, 5252, 3, 145 },
                    { 4, "Australia", "David", 160, "Warner", 205, 0, 8989, 4, 11 },
                    { 5, "West Indies", "Dwayne", 114, "Bravo", 192, 2, 4258, 5, 212 },
                    { 6, "India", "Rishabh", 87, "Pant", 69, 0, 2152, 6, 0 },
                    { 7, "South Africa", "Aiden", 134, "Markram", 76, 0, 2545, 7, 24 },
                    { 8, "New Zealand", "Lockie", 40, "Ferguson", 80, 1, 824, 8, 146 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}

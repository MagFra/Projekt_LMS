using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lexicon_LMS.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class ActivityType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActivityTypeId",
                table: "activity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ActivityType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_activity_ActivityTypeId",
                table: "activity",
                column: "ActivityTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_activity_ActivityType_ActivityTypeId",
                table: "activity",
                column: "ActivityTypeId",
                principalTable: "ActivityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_activity_ActivityType_ActivityTypeId",
                table: "activity");

            migrationBuilder.DropTable(
                name: "ActivityType");

            migrationBuilder.DropIndex(
                name: "IX_activity_ActivityTypeId",
                table: "activity");

            migrationBuilder.DropColumn(
                name: "ActivityTypeId",
                table: "activity");
        }
    }
}

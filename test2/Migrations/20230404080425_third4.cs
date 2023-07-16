using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test2.Migrations
{
    /// <inheritdoc />
    public partial class third4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dbmodules_Dbstudnets_StudentId",
                table: "Dbmodules");

            migrationBuilder.DropIndex(
                name: "IX_Dbmodules_StudentId",
                table: "Dbmodules");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Dbmodules");

            migrationBuilder.CreateTable(
                name: "ModuleStudent",
                columns: table => new
                {
                    ModulestudentsId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentModulesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleStudent", x => new { x.ModulestudentsId, x.StudentModulesId });
                    table.ForeignKey(
                        name: "FK_ModuleStudent_Dbmodules_StudentModulesId",
                        column: x => x.StudentModulesId,
                        principalTable: "Dbmodules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleStudent_Dbstudnets_ModulestudentsId",
                        column: x => x.ModulestudentsId,
                        principalTable: "Dbstudnets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModuleStudent_StudentModulesId",
                table: "ModuleStudent",
                column: "StudentModulesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModuleStudent");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Dbmodules",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dbmodules_StudentId",
                table: "Dbmodules",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dbmodules_Dbstudnets_StudentId",
                table: "Dbmodules",
                column: "StudentId",
                principalTable: "Dbstudnets",
                principalColumn: "Id");
        }
    }
}

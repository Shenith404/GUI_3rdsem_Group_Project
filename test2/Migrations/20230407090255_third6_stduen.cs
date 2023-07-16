using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test2.Migrations
{
    /// <inheritdoc />
    public partial class third6_stduen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModuleStudent");

            migrationBuilder.CreateTable(
                name: "DBstudentModules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    ModuleId = table.Column<int>(type: "INTEGER", nullable: false),
                    Grade = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBstudentModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DBstudentModules_Dbmodules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Dbmodules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DBstudentModules_Dbstudnets_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Dbstudnets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DBstudentModules_ModuleId",
                table: "DBstudentModules",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_DBstudentModules_StudentId",
                table: "DBstudentModules",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DBstudentModules");

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
    }
}

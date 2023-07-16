using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test2.Migrations
{
    /// <inheritdoc />
    public partial class fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DBstudentModules",
                table: "DBstudentModules");

            migrationBuilder.DropIndex(
                name: "IX_DBstudentModules_StudentId",
                table: "DBstudentModules");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DBstudentModules",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DBstudentModules",
                table: "DBstudentModules",
                columns: new[] { "StudentId", "ModuleId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DBstudentModules",
                table: "DBstudentModules");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DBstudentModules",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DBstudentModules",
                table: "DBstudentModules",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DBstudentModules_StudentId",
                table: "DBstudentModules",
                column: "StudentId");
        }
    }
}

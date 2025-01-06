using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clientprefs.Migrations.SqliteMigrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cookie",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cookie", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_cookie",
                columns: table => new
                {
                    account_id = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cookie_id = table.Column<int>(type: "INTEGER", nullable: false),
                    value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_cookie", x => x.account_id);
                    table.ForeignKey(
                        name: "FK_user_cookie_cookie_cookie_id",
                        column: x => x.cookie_id,
                        principalTable: "cookie",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_cookie_cookie_id",
                table: "user_cookie",
                column: "cookie_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_cookie");

            migrationBuilder.DropTable(
                name: "cookie");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace clientprefs.Migrations.NpgsqlMigrations
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
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cookie", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_cookie",
                columns: table => new
                {
                    account_id = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    cookie_id = table.Column<int>(type: "integer", nullable: false),
                    value = table.Column<string>(type: "text", nullable: false)
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

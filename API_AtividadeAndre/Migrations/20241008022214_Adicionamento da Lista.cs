using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_LINGUILEARN.Migrations
{
    /// <inheritdoc />
    public partial class AdicionamentodaLista : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.CreateTable(
                name: "ListaCompras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Itens = table.Column<string>(type: "text", nullable: false),
                    Comprado = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaCompras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListaCompras_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListaCompras");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");
        }
    }
}

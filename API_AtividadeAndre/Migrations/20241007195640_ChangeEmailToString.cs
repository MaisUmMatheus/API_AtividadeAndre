using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_LINGUILEARN.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEmailToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(char),
                oldType: "character(1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.AlterColumn<char>(
                name: "email",
                table: "Users",
                type: "character(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}

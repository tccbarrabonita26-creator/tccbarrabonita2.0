using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarraBonitaTurismo.Migrations
{
    /// <inheritdoc />
    public partial class AddColorToEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Events",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true);

            // Atualiza as cores dos eventos existentes com base no seed
            migrationBuilder.Sql("UPDATE `Events` SET `Color` = '#FF5A00' WHERE `Id` = 4");
            migrationBuilder.Sql("UPDATE `Events` SET `Color` = '#383939' WHERE `Id` = 1");
            migrationBuilder.Sql("UPDATE `Events` SET `Color` = '#8B5CF6' WHERE `Id` = 2");
            migrationBuilder.Sql("UPDATE `Events` SET `Color` = '#0EA5E9' WHERE `Id` = 3");
            migrationBuilder.Sql("UPDATE `Events` SET `Color` = '#4e051c' WHERE `Id` = 5");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Events");
        }
    }
}

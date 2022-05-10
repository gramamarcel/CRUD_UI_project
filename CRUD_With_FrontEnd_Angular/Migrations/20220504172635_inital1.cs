using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_With_FrontEnd_Angular.Migrations
{
    public partial class inital1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Proprietar_Card",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Proprietar_Card",
                table: "Cards");
        }
    }
}

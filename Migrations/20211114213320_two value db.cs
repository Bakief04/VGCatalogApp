using Microsoft.EntityFrameworkCore.Migrations;

namespace VGCatalogApp.Migrations
{
    public partial class twovaluedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "VGSystem",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "VGSystem");
        }
    }
}

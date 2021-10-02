namespace RepositoryLayer.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;
    public partial class isPinAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isPin",
                table: "Notes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isPin",
                table: "Notes");
        }
    }
}

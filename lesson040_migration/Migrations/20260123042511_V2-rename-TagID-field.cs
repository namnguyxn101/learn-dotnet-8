using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lesson040_migration.Migrations
{
    /// <inheritdoc />
    public partial class V2renameTagIDfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TagIDNew",
                table: "Tags",
                newName: "TagID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TagID",
                table: "Tags",
                newName: "TagIDNew");
        }
    }
}

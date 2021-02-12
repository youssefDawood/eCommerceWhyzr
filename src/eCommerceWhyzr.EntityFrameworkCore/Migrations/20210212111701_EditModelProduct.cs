using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerceWhyzr.Migrations
{
    public partial class EditModelProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Type",
                table: "Attributes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Attributes",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte));
        }
    }
}

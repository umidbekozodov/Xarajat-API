using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xarajat_API.Data.Migrations
{
    public partial class UserRoomCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Users");
        }
    }
}

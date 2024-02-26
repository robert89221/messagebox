using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessageBox.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMessageModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PosterId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_PosterId",
                table: "Messages",
                column: "PosterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_PosterId",
                table: "Messages",
                column: "PosterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_PosterId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_PosterId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "PosterId",
                table: "Messages");
        }
    }
}

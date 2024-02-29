using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessageBox.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMessageModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Topics_ParentTopicId",
                table: "Messages");

            migrationBuilder.AlterColumn<int>(
                name: "ParentTopicId",
                table: "Messages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Topics_ParentTopicId",
                table: "Messages",
                column: "ParentTopicId",
                principalTable: "Topics",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Topics_ParentTopicId",
                table: "Messages");

            migrationBuilder.AlterColumn<int>(
                name: "ParentTopicId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Topics_ParentTopicId",
                table: "Messages",
                column: "ParentTopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

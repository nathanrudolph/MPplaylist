using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClimbingPlaylistApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedPlaylistModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlaylistModelId",
                table: "Routes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Routes_PlaylistModelId",
                table: "Routes",
                column: "PlaylistModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Playlists_PlaylistModelId",
                table: "Routes",
                column: "PlaylistModelId",
                principalTable: "Playlists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Playlists_PlaylistModelId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_PlaylistModelId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "PlaylistModelId",
                table: "Routes");
        }
    }
}

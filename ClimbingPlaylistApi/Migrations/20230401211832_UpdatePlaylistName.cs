using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClimbingPlaylistApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePlaylistName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistModelRouteModel_Playlists_PlaylistsContainingThisRouteId",
                table: "PlaylistModelRouteModel");

            migrationBuilder.RenameColumn(
                name: "PlaylistsContainingThisRouteId",
                table: "PlaylistModelRouteModel",
                newName: "PlaylistsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistModelRouteModel_Playlists_PlaylistsId",
                table: "PlaylistModelRouteModel",
                column: "PlaylistsId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistModelRouteModel_Playlists_PlaylistsId",
                table: "PlaylistModelRouteModel");

            migrationBuilder.RenameColumn(
                name: "PlaylistsId",
                table: "PlaylistModelRouteModel",
                newName: "PlaylistsContainingThisRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistModelRouteModel_Playlists_PlaylistsContainingThisRouteId",
                table: "PlaylistModelRouteModel",
                column: "PlaylistsContainingThisRouteId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

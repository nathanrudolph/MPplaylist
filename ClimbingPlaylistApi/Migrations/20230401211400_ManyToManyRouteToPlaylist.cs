using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClimbingPlaylistApi.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyRouteToPlaylist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "PlaylistModelRouteModel",
                columns: table => new
                {
                    PlaylistsContainingThisRouteId = table.Column<int>(type: "int", nullable: false),
                    RoutesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistModelRouteModel", x => new { x.PlaylistsContainingThisRouteId, x.RoutesId });
                    table.ForeignKey(
                        name: "FK_PlaylistModelRouteModel_Playlists_PlaylistsContainingThisRouteId",
                        column: x => x.PlaylistsContainingThisRouteId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistModelRouteModel_Routes_RoutesId",
                        column: x => x.RoutesId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistModelRouteModel_RoutesId",
                table: "PlaylistModelRouteModel",
                column: "RoutesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaylistModelRouteModel");

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
    }
}

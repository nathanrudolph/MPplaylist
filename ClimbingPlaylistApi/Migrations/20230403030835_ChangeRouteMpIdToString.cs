using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClimbingPlaylistApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRouteMpIdToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaylistModelRouteModel");

            migrationBuilder.AlterColumn<string>(
                name: "MpId",
                table: "Routes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

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

            migrationBuilder.AlterColumn<long>(
                name: "MpId",
                table: "Routes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "PlaylistModelRouteModel",
                columns: table => new
                {
                    PlaylistsId = table.Column<int>(type: "int", nullable: false),
                    RoutesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistModelRouteModel", x => new { x.PlaylistsId, x.RoutesId });
                    table.ForeignKey(
                        name: "FK_PlaylistModelRouteModel_Playlists_PlaylistsId",
                        column: x => x.PlaylistsId,
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
    }
}

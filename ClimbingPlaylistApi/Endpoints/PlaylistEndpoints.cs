using ClimbingPlaylistApi.Models;
using ClimbingPlaylistApi.Services;
using ClimbingPlaylistApi.Validators;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace ClimbingPlaylistApi.Endpoints
{
    public static class PlaylistEndpoints
    {
        public static void ConnectPlaylistEndpoints(this WebApplication app)
        {
            app.MapGet("api/playlists", 
                (IPlaylistService service) => 
                Get(service));
            app.MapGet("api/playlists/{id}", 
                (int id, IPlaylistService service) => 
                GetById(id,service));
            app.MapPost("api/playlists", 
                ([FromBody] PlaylistModel playlist, IPlaylistService service) => 
                Post(playlist,service));
            app.MapPut("api/playlists", 
                ([FromBody] PlaylistModel playlist, IPlaylistService service) => 
                Put(playlist, service));
            app.MapDelete("api/playlists", 
                ([FromBody] PlaylistModel playlist, IPlaylistService service) => 
                Delete(playlist,service));

            app.MapPost("api/playlists/{playlistId}/routes", 
                (int playlistId, [FromBody] string routeUrl, IPlaylistService service) => 
                AddRouteToPlaylist(playlistId,routeUrl,service));
            app.MapDelete("api/playlists/{playlistId}/routes/{routeId}", 
                (int playlistId, int routeId, IPlaylistService service) => 
                DeleteRouteFromPlaylist(playlistId,routeId,service));
        }

        private static IResult Get(IPlaylistService playlistService)
        {
            try
            {
                return Results.Ok(playlistService.Get());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static IResult GetById(int id, IPlaylistService playlistService)
        {
            try
            {
                var output = playlistService.GetPlaylistById(id);
                if (output == null) 
                { 
                    return Results.NotFound(); 
                }
                return Results.Ok(output);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static IResult Post(PlaylistModel playlist, IPlaylistService playlistService)
        {
            try
            {
                playlistService.AddPlaylist(playlist);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static IResult Put(PlaylistModel playlist, IPlaylistService playlistService)
        {
            try
            {
                playlistService.UpdatePlaylist(playlist);
                return Results.Ok();
            }
            catch(Exception ex) { return Results.Problem(ex.Message); }
        }

        private static IResult Delete(PlaylistModel playlist, IPlaylistService playlistService)
        {
            try
            {
                playlistService.DeletePlaylist(playlist);
                return Results.Ok();
            }
            catch( Exception ex) { return Results.Problem( ex.Message); }
        }

        private static IResult AddRouteToPlaylist(int playlistId, string routeUrl, IPlaylistService playlistService)
        {
            try
            {
                playlistService.AddRouteToPlaylist(playlistId,routeUrl);
                return Results.Ok();
            }
            catch (Exception ex) { return Results.Problem(ex.Message); }
        }

        private static IResult DeleteRouteFromPlaylist(int playlistId, int routeId, IPlaylistService playlistService)
        {
            try
            {
                playlistService.DeleteRouteFromPlaylist(playlistId, routeId);
                return Results.Ok();
            }
            catch (Exception ex) { return Results.Problem(ex.Message); }
        }

        //TODO: add validation of models at endpoint level
        //PlaylistModelValidator validator = new PlaylistModelValidator();
        //validator.Validate(playlist);
    }
}

using ClimbingPlaylistApi.Models;
using ClimbingPlaylistApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClimbingPlaylistApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        public PlaylistController(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        private readonly IPlaylistService _playlistService;

        // GET api/<PlaylistController>
        [HttpGet]
        public async Task<IResult> GetPlaylist()
        {
            try
            {
                return Results.Ok(await _playlistService.GetAsync());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        // GET api/<PlaylistController>/5
        [HttpGet("{id}")]
        public async Task<IResult> GetPlaylistById(int id)
        {
            try
            {
                var output = await _playlistService.GetPlaylistByIdAsync(id);
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

        [HttpPost]
        public async Task<IResult> PostNewEmptyPlaylist([FromBody] string playlistName)
        {
            try
            {
                int id = await _playlistService.AddNewEmptyPlaylistAsync(playlistName);
                return Results.Ok(id);
            }
            catch (Exception ex) { return Results.Problem(ex.Message);}
        }

        [HttpPut("{id}")]
        public async Task<IResult> UpdatePlaylistName(int id, [FromBody] string playlistName)
        {
            try
            {
                PlaylistModel? playlist = await _playlistService.GetPlaylistByIdAsync(id);
                if (playlist == null)
                {
                    return Results.NotFound();
                }
                playlist.Name = playlistName;
                await _playlistService.UpdatePlaylist(playlist);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        // DELETE api/<PlaylistController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> DeletePlaylist(int id)
        {
            try
            {
                PlaylistModel? playlist = await _playlistService.GetPlaylistByIdAsync(id);
                if (playlist == null)
                {
                    return Results.NotFound();
                }
                await _playlistService.DeletePlaylist(playlist);
                return Results.Ok();
            }
            catch (Exception ex) { return Results.Problem(ex.Message); }
        }

        [HttpPost("{id}/routes")]
        public async Task<IResult> AddRouteToPlaylist(int id, [FromBody] string routeUrl)
        {
            try
            {
                int newRouteId = await _playlistService.AddRouteToPlaylistByUrlAsync(id, routeUrl);
                return newRouteId switch
                {
                    -1 => Results.NotFound(routeUrl),
                    -2 => Results.NotFound(id),
                    -3 => Results.Conflict(routeUrl),
                    _ => Results.Ok(newRouteId),
                };
            }
            catch (Exception ex) { return Results.Problem(ex.Message); }
        }

        [HttpDelete("{playlistId}/routes/{routeId}")]
        public async Task<IResult> DeleteRouteFromPlaylist(int playlistId, int routeId)
        {
            try
            {
                var result = await _playlistService.DeleteRouteFromPlaylistByUrlAsync(playlistId, routeId);
                return result switch
                {
                    false => Results.NotFound(),
                    true => Results.Ok(),
                };
            }
            catch (Exception ex) { return Results.Problem(ex.Message); }
        }
    }
}

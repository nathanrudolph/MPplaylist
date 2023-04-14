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
        public async Task<IResult> Get(IPlaylistService playlistService)
        {
            try
            {
                return Results.Ok(await playlistService.GetAsync());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        // GET api/<PlaylistController>/5
        [HttpGet("{id}")]
        public async Task<IResult> GetById(int id, IPlaylistService playlistService)
        {
            try
            {
                var output = await playlistService.GetPlaylistByIdAsync(id);
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
        public async Task<IResult> PostNewEmptyPlaylist([FromBody] string playlistName, IPlaylistService playlistService)
        {
            try
            {
                int id = await playlistService.AddNewEmptyPlaylistAsync(playlistName);
                return Results.Ok(id);
            }
            catch (Exception ex) { return Results.Problem(ex.Message);}
        }

        //// PUT api/<PlaylistController>/5
        //[HttpPut("{id}")]
        //public IResult Put([FromBody] PlaylistModel playlist, IPlaylistService playlistService)
        //{
        //    try
        //    {
        //        playlistService.UpdatePlaylist(playlist);
        //        return Results.Ok();
        //    }
        //    catch (Exception ex) { return Results.Problem(ex.Message); }
        //}

        // DELETE api/<PlaylistController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id, IPlaylistService playlistService)
        {
            try
            {
                PlaylistModel? playlist = await playlistService.GetPlaylistByIdAsync(id);
                if (playlist == null)
                {
                    return Results.NotFound();
                }
                await playlistService.DeletePlaylist(playlist);
                return Results.Ok();
            }
            catch (Exception ex) { return Results.Problem(ex.Message); }
        }

        [HttpPost("{id}/routes")]
        public async Task<IResult> AddRouteToPlaylist(int id, [FromBody] string routeUrl, IPlaylistService playlistService)
        {
            try
            {
                int newRouteId = await playlistService.AddRouteToPlaylistByUrlAsync(id, routeUrl);
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
        public async Task<IResult> DeleteRouteFromPlaylist(int playlistId, int routeId, IPlaylistService playlistService)
        {
            try
            {
                var result = await playlistService.DeleteRouteFromPlaylistByUrlAsync(playlistId, routeId);
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

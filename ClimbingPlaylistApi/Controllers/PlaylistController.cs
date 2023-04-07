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

        // GET: api/<PlaylistController>
        [HttpGet]
        public IResult Get(IPlaylistService playlistService)
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

        // GET api/<PlaylistController>/5
        [HttpGet("{id}")]
        public IResult Get(int id, IPlaylistService playlistService)
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

        [HttpPost]
        public async Task<IResult> PostNewEmptyPlaylist([FromBody] string playlistName, IPlaylistService playlistService)
        {
            try
            {
                int id = await playlistService.AddNewEmptyPlaylist(playlistName);
                return Results.Ok(id);
            }
            catch (Exception ex) { return Results.Problem(ex.Message);}
        }

        // PUT api/<PlaylistController>/5
        [HttpPut("{id}")]
        public IResult Put([FromBody] PlaylistModel playlist, IPlaylistService playlistService)
        {
            try
            {
                playlistService.UpdatePlaylist(playlist);
                return Results.Ok();
            }
            catch (Exception ex) { return Results.Problem(ex.Message); }
        }

        // DELETE api/<PlaylistController>/5
        [HttpDelete("{id}")]
        public IResult Delete(int id, IPlaylistService playlistService)
        {
            try
            {
                var playlist = playlistService.GetPlaylistById(id);
                if (playlist == null)
                {
                    return Results.NotFound();
                }
                playlistService.DeletePlaylist(playlist);
                return Results.Ok();
            }
            catch (Exception ex) { return Results.Problem(ex.Message); }
        }

        [HttpPost("{id}/routes")]
        public IResult AddRouteToPlaylist(int id, [FromBody] string routeUrl, IPlaylistService playlistService)
        {
            try
            {
                playlistService.AddRouteToPlaylist(id, routeUrl);
                return Results.Ok();
            }
            catch (Exception ex) { return Results.Problem(ex.Message); }
        }

        [HttpDelete("{playlistId}/routes/{routeId}")]
        public IResult DeleteRouteFromPlaylist(int playlistId, int routeId, IPlaylistService playlistService)
        {
            try
            {
                playlistService.DeleteRouteFromPlaylist(playlistId, routeId);
                return Results.Ok();
            }
            catch (Exception ex) { return Results.Problem(ex.Message); }
        }
    }
}

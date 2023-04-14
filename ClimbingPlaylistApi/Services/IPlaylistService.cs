using ClimbingPlaylistApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingPlaylistApi.Services
{
    public interface IPlaylistService
    {
        Task<List<PlaylistModel>> GetAsync();
        Task<PlaylistModel?> GetPlaylistByIdAsync(int id);
        Task<int> AddNewEmptyPlaylistAsync (string playlistName);
        Task UpdatePlaylist(PlaylistModel playlist);
        Task DeletePlaylist(PlaylistModel playlist);
        Task<int> AddRouteToPlaylistByUrlAsync(int playlistId, string routeUrl);
        Task<int> AddRouteModelToPlaylistModelAsync(PlaylistModel playlist, RouteModel route);
        Task<bool> DeleteRouteModelFromPlaylistModelAsync(PlaylistModel playlist, RouteModel route);
        
        Task<bool> DeleteRouteFromPlaylistByUrlAsync(int playlistId, int  routeId);
    }
}

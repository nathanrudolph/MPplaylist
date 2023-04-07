using ClimbingPlaylistApi.Models;

namespace ClimbingPlaylistApi.Services
{
    public interface IDbService
    {
        Task AddPlaylistAsync(PlaylistModel playlist);
        Task AddRouteAsync(RouteModel route);
        Task DeletePlaylistAsync(PlaylistModel playlist);
        Task DeleteRouteAsync(RouteModel route);
        Task<PlaylistModel?> GetPlaylistAsync(int playlistId);
        Task UpdatePlaylistAsync(PlaylistModel playlist);
        Task UpdateRouteAsync(RouteModel route);
        Task<List<PlaylistModel>> GetAllPlaylistsAsync();
        Task<List<RouteModel>> GetAllRoutesAsync();
        Task<RouteModel?> GetRouteByMpIdAsync(string MpId);
        Task<RouteModel?> GetRouteByIdAsync(int id);
        Task<List<RouteModel>> GetRoutesInPlaylistAsync(int PlaylistId);
        Task<List<string>> GetPlaylistNamesAsync();
    }
}
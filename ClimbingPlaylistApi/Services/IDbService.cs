using ClimbingPlaylistApi.Models;

namespace ClimbingPlaylistApi.Services
{
    public interface IDbService
    {
        Task AddPlaylist(PlaylistModel playlist);
        Task AddRoute(RouteModel route);
        Task RemovePlaylist(PlaylistModel playlist);
        Task RemoveRoute(RouteModel route);
        Task<PlaylistModel?> GetPlaylist(int playlistId);
        Task UpdatePlaylist(PlaylistModel playlist);
        Task UpdateRoute(RouteModel route);
        Task<List<PlaylistModel>> GetAllPlaylists();
        Task<List<RouteModel>> GetAllRoutes();
        Task<RouteModel?> GetRoute(string MpId);
        Task<RouteModel?> GetRoute(int id);
        Task<List<RouteModel>> GetRoutesInPlaylist(int PlaylistId);
        Task<List<string>> GetPlaylistNames();
    }
}
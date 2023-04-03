using ClimbingPlaylistApi.Models;

namespace ClimbingPlaylistApi.Services
{
    public interface IDbService
    {
        void AddPlaylist(PlaylistModel playlist);
        void AddRoute(RouteModel route);
        void RemovePlaylist(PlaylistModel playlist);
        void RemoveRoute(RouteModel route);
        PlaylistModel GetPlaylist(int playlistId);
        void UpdatePlaylist(PlaylistModel playlist);
        void UpdateRoute(RouteModel route);
        List<PlaylistModel> GetAllPlaylists();
        List<RouteModel> GetAllRoutes();
        RouteModel GetRoute(string MpId);
        List<RouteModel> GetRoutesInPlaylist(int PlaylistId);
    }
}
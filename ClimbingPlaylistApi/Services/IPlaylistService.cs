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
        void AddPlaylist(PlaylistModel playlist);
        void CreateNewEmptyPlaylist (string newName);
        void DeletePlaylist(PlaylistModel playlist);
        List<PlaylistModel> Get();
        PlaylistModel? GetPlaylistById(int id);
        void AddRouteToPlaylist(PlaylistModel playlist, RouteModel route);
        void DeleteRouteFromPlaylist(PlaylistModel playlist, RouteModel route);
        //RouteModel? GetRouteInPlaylist(PlaylistModel playlist, string RouteMpId);
        void UpdatePlaylist(PlaylistModel playlist);
        void AddRouteToPlaylist(int playlistId, string routeUrl);
        void DeleteRouteFromPlaylist(int playlistId, int  routeId);
    }
}

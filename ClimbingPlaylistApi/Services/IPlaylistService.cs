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
        public List<PlaylistModel> Playlists { get; set; }

        void AddPlaylist(PlaylistModel playlist);
        void RemovePlaylist(PlaylistModel playlist);
        List<string> GetPlaylistNames();
        PlaylistModel GetPlaylist(int id);
        void AddRouteToPlaylist(PlaylistModel playlist, RouteModel route);
        void RemoveRouteFromPlaylist(PlaylistModel playlist, RouteModel route);
        List<RouteModel> GetAllRoutesInPlaylist(PlaylistModel playlist);
        RouteModel GetRouteInPlaylist(PlaylistModel playlist, int id);
        void RenamePlaylist(PlaylistModel playlist, string newName);
    }
}

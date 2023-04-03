using ClimbingPlaylistApi.Domain;
using ClimbingPlaylistApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingPlaylistApi.Services
{
    public class PlaylistService : IPlaylistService
    {
        public PlaylistService(IDbService dbService, IRouteModelHandler routeHandler)
        {
            _dbService = dbService;
            _routeHandler = routeHandler;
            OnInitialize();
        }

        private void OnInitialize()
        {
            Playlists = _dbService.GetAllPlaylists();
            Routes = _dbService.GetAllRoutes();
        }

        private IRouteModelHandler _routeHandler { get; set; }
        private IDbService _dbService { get; set; }

        public List<PlaylistModel> Playlists { get; set; }

        public List<RouteModel> Routes { get; set; }

        public void AddPlaylist(PlaylistModel playlist)
        {
            if (Playlists.Any(p => p.Name == playlist.Name))
            {
                var message = $"Playlist with name \"{playlist.Name}\" already exists.";
                throw new ArgumentException(message);
            }
            Playlists.Add(playlist);
            _dbService.AddPlaylist(playlist);
        }

        public void CreateNewEmptyPlaylist(string playlistName)
        {
            if (Playlists.Any(p => p.Name == playlistName))
            {
                var message = $"Playlist with name \"{playlistName}\" already exists.";
                throw new ArgumentException(message);
            }
            Playlists.Add(new PlaylistModel(playlistName));
            _dbService.AddPlaylist(new PlaylistModel(playlistName));
        }

        public void RemovePlaylist(PlaylistModel playlist)
        {
            if (!Playlists.Any(p => p.Name == playlist.Name))
            {
                var message = $"Playlist \"{playlist.Name}\" was not found.";
                throw new ArgumentException(message);
            }
            Playlists.Remove(playlist);
            _dbService.RemovePlaylist(playlist);
        }

        public List<string> GetPlaylistNames()
        {
            return Playlists.Select(p => p.Name).ToList();
        }

        public PlaylistModel GetPlaylist(int id)
        {
            //TODO: set "default" playlist if playlist isn't found?
            try
            {
                return Playlists.First(p => p.Id == id);
            }
            catch
            {
                var message = $"Playlist {id} does not exist.";
                throw new ArgumentException(message);
            }
        }

        public void AddRouteToPlaylist(PlaylistModel playlist, RouteModel route)
        {
            if (playlist.Routes.Any(r => r.MpId == route.MpId))
            {
                var message = $"Route \"{route.Name}\" is already in this playlist.";
                throw new ArgumentException(message);
            }
            playlist.Routes.Add(route);
            route.Playlists.Add(playlist);
            _dbService.UpdatePlaylist(playlist);
            _dbService.UpdateRoute(route);
        }

        public void AddRouteToPlaylist(PlaylistModel playlist, string routeUrl)
        {
            var route = _routeHandler.GetRoute(routeUrl);
            playlist.Routes.Add(route);
            route.Playlists.Add(playlist);
            _dbService.UpdatePlaylist(playlist);
            _dbService.UpdateRoute(route);

        }

        public void RemoveRouteFromPlaylist(PlaylistModel playlist, RouteModel route)
        {
            if (!playlist.Routes.Any(r => r.MpId == route.MpId))
            {
                var message = $"Route \"{route.MpId}\" was not found in playlist {playlist.Id}.";
                throw new ArgumentException(message);
            }
            playlist.Routes.Remove(route);
            route.Playlists.Remove(playlist);
            _dbService.UpdatePlaylist(playlist);
            _dbService.UpdateRoute(route);
        }

        public List<RouteModel> GetAllRoutesInPlaylist(PlaylistModel playlist)
        {
            return playlist.Routes;
        }

        public RouteModel GetRouteInPlaylist(PlaylistModel playlist, int id)
        {
            try
            {
                return playlist.Routes.FirstOrDefault(r => r.MpId == id);
            }
            catch (NullReferenceException)
            {
                var message = $"Route {id} was not found in the playlist.";
                throw new KeyNotFoundException(message);
            }
        }

        public void RenamePlaylist(PlaylistModel playlist, string newName)
        {
            //TODO: check if new playlist name already exists
            playlist.Name = newName;
            _dbService.UpdatePlaylist(playlist);
        }
    }
}

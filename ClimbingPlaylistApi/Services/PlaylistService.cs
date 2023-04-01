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
        public PlaylistService(IDbService dbService)
        {
            _dbService = dbService;
        }

        //TODO: update db and save state after each CRUD operation?

        IDbService _dbService;

        public List<PlaylistModel> Playlists { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AddPlaylist(PlaylistModel playlist)
        {
            if (Playlists.Any(p => p.Name == playlist.Name))
            {
                var message = $"Playlist with name \"{playlist.Name}\" already exists.";
                throw new ArgumentException(message);
            }
            Playlists.Add(playlist);
        }

        public void RemovePlaylist(PlaylistModel playlist)
        {
            if (!Playlists.Any(p => p.Name == playlist.Name))
            {
                var message = $"Playlist \"{playlist.Name}\" was not found.";
                throw new ArgumentException(message);
            }
            Playlists.Remove(playlist);
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
            if (playlist.Routes.Any(r => r.Id == route.Id))
            {
                var message = $"Route \"{route.Name}\" is already in this playlist.";
                throw new ArgumentException(message);
            }
            playlist.Routes.Add(route);
        }

        public void RemoveRouteFromPlaylist(PlaylistModel playlist, RouteModel route)
        {
            if (!playlist.Routes.Any(r => r.Id == route.Id))
            {
                var message = $"Route \"{route.Id}\" was not found in playlist {playlist.Id}.";
                throw new ArgumentException(message);
            }
            playlist.Routes.Remove(route);
        }

        public List<RouteModel> GetAllRoutesInPlaylist(PlaylistModel playlist)
        {
            return playlist.Routes;
        }

        public RouteModel GetRouteInPlaylist(PlaylistModel playlist, int id)
        {
            try
            {
                return playlist.Routes.FirstOrDefault(r => r.Id == id);
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
        }
    }
}

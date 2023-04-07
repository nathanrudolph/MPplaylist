using ClimbingPlaylistApi.Domain;
using ClimbingPlaylistApi.Models;
using ClimbingPlaylistApi.Validators;
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
        }

        private IRouteModelHandler _routeHandler { get; set; }
        private IDbService _dbService { get; set; }

        public void AddPlaylist(PlaylistModel playlist)
        {
            _dbService.AddPlaylistAsync(playlist);
        }

        public void CreateNewEmptyPlaylist(string playlistName)
        {
            _dbService.AddPlaylistAsync(new PlaylistModel() { Name=playlistName});
            //TODO: add dbService notification of new Id to pass back to user
        }

        public void DeletePlaylist(PlaylistModel playlist)
        {
            _dbService.DeletePlaylistAsync(playlist);
        }

        public List<string> GetPlaylistNames()
        {
            return _dbService.GetPlaylistNamesAsync().Result;
        }

        public PlaylistModel? GetPlaylistById(int id)
        {
            return _dbService.GetPlaylistAsync(id).Result;
        }

        public void AddRouteToPlaylist(PlaylistModel playlist, RouteModel route)
        {
            if (playlist.Routes.Any(r => r.MpId == route.MpId))
            {
                var message = $"Route \"{route.Name}\" is already in this playlist.";
                throw new ArgumentException(message);
            }
            playlist.Routes.Add(route);
            _dbService.UpdatePlaylistAsync(playlist);

        }

        public void AddRouteToPlaylist(PlaylistModel playlist, string routeUrl)
        {
            var route = _routeHandler.GetRoute(routeUrl);
            playlist.Routes.Add(route);
            _dbService.UpdatePlaylistAsync(playlist);
        }

        public void DeleteRouteFromPlaylist(PlaylistModel playlist, RouteModel route)
        {
            if (!playlist.Routes.Any(r => r.MpId == route.MpId))
            {
                var message = $"Route \"{route.Name}\" was not found in playlist {playlist.Id}.";
                throw new ArgumentException(message);
            }
            playlist.Routes.Remove(route);
            _dbService.UpdatePlaylistAsync(playlist);
        }

        //public List<RouteModel> GetAllRoutesInPlaylist(PlaylistModel playlist)
        //{
        //    return playlist.Routes;
        //}

        //public RouteModel GetRouteInPlaylist(PlaylistModel playlist, string RouteMpId)
        //{
        //    try
        //    {
        //        return playlist.Routes.FirstOrDefault(r => r.MpId == RouteMpId);
        //    }
        //    catch (NullReferenceException)
        //    {
        //        var message = $"Route {RouteMpId} was not found in the playlist.";
        //        throw new KeyNotFoundException(message);
        //    }
        //}

        public void UpdatePlaylist(PlaylistModel playlist)
        {
            _dbService.UpdatePlaylistAsync(playlist);
        }

        public List<PlaylistModel> Get()
        {
            return _dbService.GetAllPlaylistsAsync().Result;
        }

        public void AddRouteToPlaylist(int playlistId, string routeUrl)
        {
            RouteModel route = _routeHandler.GetRoute(routeUrl);
            PlaylistModel? playlist = _dbService.GetPlaylistAsync(playlistId).Result;
            if (playlist == null) { throw new KeyNotFoundException($"Playlist with ID {playlistId} was not found."); }
            AddRouteToPlaylist(playlist, route);
        }

        public void DeleteRouteFromPlaylist(int playlistId, int routeId)
        {
            //RouteModel route = _dbService.GetRoute(routeId);
            PlaylistModel? playlist = _dbService.GetPlaylistAsync(playlistId).Result;
            if (playlist == null)
            {
                throw new KeyNotFoundException($"Playlist with ID {playlistId} was not found.");
            }
            RouteModel? route = playlist.Routes.Where(r => r.Id == routeId).FirstOrDefault();
            if (route == null)
            {
                throw new KeyNotFoundException($"Route with ID {routeId} was not found in playlist {playlistId}.");
            }
            DeleteRouteFromPlaylist(playlist, route);
        }

        //private void ValidatePlaylist(PlaylistModel playlist)
        //{
        //    throw new NotImplementedException();
        //    //var names = _dbService.GetPlaylistNames();
        //    //if (names.Contains(playlistName))
        //    //{
        //    //    var message = $"Playlist with name \"{playlistName}\" already exists.";
        //    //    throw new ArgumentException(message);
        //    //}
        //}

        //private void ValidateRoute(RouteModel route)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

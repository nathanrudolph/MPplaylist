using ClimbingPlaylistApi.Domain;
using ClimbingPlaylistApi.Models;
using ClimbingPlaylistApi.Validators;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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

        public async Task<List<PlaylistModel>> GetAsync()
        {
            return await _dbService.GetAllPlaylistsAsync();
        }

        public async Task<PlaylistModel?> GetPlaylistByIdAsync(int id)
        {
            return await _dbService.GetPlaylistAsync(id);
        }

        public async Task<int> AddNewEmptyPlaylistAsync(string playlistName)
        {
            int id = await _dbService.AddPlaylistAsync(new PlaylistModel() { Name=playlistName});
            return id;
        }

        public async Task DeletePlaylist(PlaylistModel playlist)
        {
            await _dbService.DeletePlaylistAsync(playlist);
        }

        //public List<string> GetPlaylistNames()
        //{
        //    return _dbService.GetPlaylistNamesAsync().Result;
        //}

        public async Task<int> AddRouteModelToPlaylistModelAsync(PlaylistModel playlist, RouteModel route)
        {
            if (playlist.Routes.Any(r => r.MpId == route.MpId))
            {
                return -3;
            }
            playlist.Routes.Add(route);
            await _dbService.UpdatePlaylistAsync(playlist);
            return route.Id;
        }

        public async Task<int> AddRouteToPlaylistByUrlAsync(int playlistId, string routeUrl)
        {
            RouteModel? route = await _routeHandler.GetRoute(routeUrl);
            if (route == null)
                { return -1; }
            PlaylistModel? playlist = await _dbService.GetPlaylistAsync(playlistId);
            if (playlist == null)
                { return -2; }
            int newRouteId = await AddRouteModelToPlaylistModelAsync(playlist, route);
            return newRouteId;
        }

        //public async Task<int> AddRouteToPlaylistAsync(PlaylistModel playlist, string routeUrl)
        //{
        //    var route = _routeHandler.GetRoute(routeUrl);
        //    if (route == null)
        //    {
        //        return 0;
        //    }
        //    playlist.Routes.Add(route);
        //    await _dbService.UpdatePlaylistAsync(playlist);
        //    return route.Id;
        //}

        public async Task<bool> DeleteRouteModelFromPlaylistModelAsync(PlaylistModel playlist, RouteModel route)
        {
            if (!playlist.Routes.Any(r => r.MpId == route.MpId))
            {
                //var message = $"Route \"{route.Name}\" was not found in playlist {playlist.Id}.";
                //throw new ArgumentException(message);
                return false;
            }
            playlist.Routes.Remove(route);
            await _dbService.UpdatePlaylistAsync(playlist);
            return true;
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

        public async Task UpdatePlaylist(PlaylistModel playlist)
        {
            await _dbService.UpdatePlaylistAsync(playlist);
        }

        public async Task<bool> DeleteRouteFromPlaylistByUrlAsync(int playlistId, int routeId)
        {
            //RouteModel route = _dbService.GetRoute(routeId);
            PlaylistModel? playlist = _dbService.GetPlaylistAsync(playlistId).Result;
            if (playlist == null)
            {
                //throw new KeyNotFoundException($"Playlist with ID {playlistId} was not found.")
                return false;
            }
            RouteModel? route = playlist.Routes.Where(r => r.Id == routeId).FirstOrDefault();
            if (route == null)
            {
                //throw new KeyNotFoundException($"Route with ID {routeId} was not found in playlist {playlistId}.");
                return false;
            }
            return await DeleteRouteModelFromPlaylistModelAsync(playlist, route);
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

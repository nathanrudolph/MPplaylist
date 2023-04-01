using ClimbingPlaylistApi.Database;
using ClimbingPlaylistApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ClimbingPlaylistApi.Services
{
    public class DbService : IDbService
    {
        public DbService(IPlaylistRepository playlistRepo, IRouteRepository routeRepo, DbContextOptions options)
        {
            climbingDbContext = new ClimbingDbContext(options);
            _playlistRepo = playlistRepo;
            _routeRepo = routeRepo;
        }

        private IPlaylistRepository _playlistRepo;
        private IRouteRepository _routeRepo;
        private ClimbingDbContext climbingDbContext;

        public void AddPlaylist(PlaylistModel playlist)
        {
            _playlistRepo.Add(playlist);
        }

        public void UpdatePlaylist(PlaylistModel playlist)
        {
            _playlistRepo.Update(playlist);
        }

        public void RemovePlaylist(PlaylistModel playlist)
        {
            _playlistRepo.Remove(playlist);
        }

        public PlaylistModel GetPlaylist(int playlistId)
        {
            return _playlistRepo.Get(playlistId);
        }

        public void AddRoute(RouteModel route)
        {
            _routeRepo.Add(route);
        }

        public void UpdateRoute(uint routeId, RouteModel route)
        {
            _routeRepo.Update(routeId, route);
        }

        public void RemoveRoute(RouteModel route)
        {
            _routeRepo.Remove(route);
        }

        public RouteModel GetRoute(uint routeId)
        {
            return _routeRepo.Get(routeId);
        }


    }
}

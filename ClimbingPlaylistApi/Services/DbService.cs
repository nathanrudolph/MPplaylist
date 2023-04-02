using ClimbingPlaylistApi.Database;
using ClimbingPlaylistApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ClimbingPlaylistApi.Services
{
    public class DbService : IDbService
    {
        public DbService(ClimbingDbContext dbContext)
        {
            db = dbContext;
        }

        private ClimbingDbContext db;

        public void AddPlaylist(PlaylistModel playlist)
        {
            db.Add(playlist);
            db.SaveChanges();
        }

        public void UpdatePlaylist(PlaylistModel playlist)
        {
            db.Update(playlist);
            db.SaveChanges();
        }

        public void RemovePlaylist(PlaylistModel playlist)
        {
            db.Remove(playlist);
            db.SaveChanges();
        }

        public PlaylistModel GetPlaylist(int playlistId)
        {
            var output = db.Find(typeof(PlaylistModel), playlistId);
            if (output == null)
            {
                var message = $"Playlist with Id {playlistId} not found.";
                throw new ArgumentException(message);
            }
            return (PlaylistModel)output;
        }

        public void AddRoute(RouteModel route)
        {
            db.Add(route);
            db.SaveChanges();
        }

        public void UpdateRoute(RouteModel route)
        {
            db.Update(route);
            db.SaveChanges();
        }

        public void RemoveRoute(RouteModel route)
        {
            db.Remove(route);
            db.SaveChanges();
        }

        public RouteModel GetRoute(uint routeId)
        {
            var output = db.Find(typeof(RouteModel), routeId);
            if (output == null)
            {
                var message = $"Route with Id {routeId} not found.";
                throw new ArgumentException(message);
            }
            return (RouteModel)output;
        }

        public List<PlaylistModel> GetAllPlaylists()
        {
            return db.Playlists.ToList();
        }

        public List<RouteModel> GetAllRoutes()
        {
            return db.Routes.ToList();
        }
    }
}

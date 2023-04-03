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
            var output = db.Playlists.Where(p => p.Id == playlistId).Include(p => p.Routes).First();
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

        public RouteModel GetRoute(string MpId)
        {
            var output = db.Routes.Where(r => r.MpId == MpId).FirstOrDefault();
            if (output == null)
            {
                var message = $"Route with MpId {MpId} not found.";
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

        public List<RouteModel> GetRoutesInPlaylist(int PlaylistId)
        {
            var playlist = db.Playlists.Where(p => p.Id == PlaylistId).FirstOrDefault();
            if (playlist == null)
            {
                var message = $"Playlist with ID {PlaylistId} was not found.";
                throw new ArgumentException(message);
            }
            return playlist.Routes.ToList();
        }
    }
}

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

        private readonly ClimbingDbContext db;

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

        public PlaylistModel? GetPlaylist(int playlistId)
        {
            return db.Playlists.Where(p => p.Id == playlistId).Include(p => p.Routes).First();
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

        public RouteModel? GetRoute(string MpId)
        {
            return db.Routes.Where(r => r.MpId == MpId).FirstOrDefault();
        }

        public RouteModel? GetRoute(int Id)
        {
            return db.Routes.Where(r => r.Id == Id).FirstOrDefault();
        }

        public List<PlaylistModel> GetAllPlaylists()
        {
            return db.Playlists.Include(p => p.Routes).ToList();
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

        public List<string> GetPlaylistNames()
        {
            return db.Playlists.Select(p => p.Name).ToList();
        }
    }
}

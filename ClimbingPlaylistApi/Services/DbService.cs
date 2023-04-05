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

        public async Task AddPlaylist(PlaylistModel playlist)
        {
            await db.AddAsync(playlist);
            await db.SaveChangesAsync();
            //return playlist.Id;
        }

        public async Task UpdatePlaylist(PlaylistModel playlist)
        {
            db.Update(playlist);
            await db.SaveChangesAsync();
        }

        public async Task RemovePlaylist(PlaylistModel playlist)
        {
            db.Remove(playlist);
            await db.SaveChangesAsync();
        }

        public async Task<PlaylistModel?> GetPlaylist(int playlistId)
        {
            return await db.Playlists.Include(p => p.Routes).FirstOrDefaultAsync(p => p.Id == playlistId);
        }

        public async Task AddRoute(RouteModel route)
        {
            await db.AddAsync(route);
            await db.SaveChangesAsync();
        }

        public async Task UpdateRoute(RouteModel route)
        {
            db.Update(route);
            await db.SaveChangesAsync();
        }

        public async Task RemoveRoute(RouteModel route)
        {
            db.Remove(route);
            await db.SaveChangesAsync();
        }

        public async Task<RouteModel?> GetRouteByMpId(string MpId)
        {
            return await db.Routes.FirstOrDefaultAsync(r => r.MpId == MpId);
        }

        public async Task<RouteModel?> GetRouteById(int Id)
        {
            return await db.Routes.FirstOrDefaultAsync(r => r.Id == Id);
        }

        public async Task<List<PlaylistModel>> GetAllPlaylists()
        {
            return await db.Playlists.ToListAsync();
        }

        public async Task<List<RouteModel>> GetAllRoutes()
        {
            return await db.Routes.ToListAsync();
        }

        public async Task<List<RouteModel>> GetRoutesInPlaylist(int PlaylistId)
        {
            return await db.Routes.Where(r => r.PlaylistModelId == PlaylistId).ToListAsync();
        }

        public async Task<List<string>> GetPlaylistNames()
        {
            return await db.Playlists.Select(p => p.Name).ToListAsync();
        }
    }
}

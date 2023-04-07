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

        public async Task<int> AddPlaylistAsync(PlaylistModel playlist)
        {
            await db.AddAsync(playlist);
            await db.SaveChangesAsync();
            return playlist.Id;
        }

        public async Task UpdatePlaylistAsync(PlaylistModel playlist)
        {
            db.Update(playlist);
            await db.SaveChangesAsync();
        }

        public async Task DeletePlaylistAsync(PlaylistModel playlist)
        {
            db.Remove(playlist);
            await db.SaveChangesAsync();
        }

        public async Task<PlaylistModel?> GetPlaylistAsync(int playlistId)
        {
            return await db.Playlists.Include(p => p.Routes).FirstOrDefaultAsync(p => p.Id == playlistId);
        }

        public async Task AddRouteAsync(RouteModel route)
        {
            await db.AddAsync(route);
            await db.SaveChangesAsync();
        }

        public async Task UpdateRouteAsync(RouteModel route)
        {
            db.Update(route);
            await db.SaveChangesAsync();
        }

        public async Task DeleteRouteAsync(RouteModel route)
        {
            db.Remove(route);
            await db.SaveChangesAsync();
        }

        public async Task<RouteModel?> GetRouteByMpIdAsync(string MpId)
        {
            return await db.Routes.FirstOrDefaultAsync(r => r.MpId == MpId);
        }

        public async Task<RouteModel?> GetRouteByIdAsync(int Id)
        {
            return await db.Routes.FirstOrDefaultAsync(r => r.Id == Id);
        }

        public async Task<List<PlaylistModel>> GetAllPlaylistsAsync()
        {
            return await db.Playlists.ToListAsync();
        }

        public async Task<List<RouteModel>> GetAllRoutesAsync()
        {
            return await db.Routes.ToListAsync();
        }

        public async Task<List<RouteModel>> GetRoutesInPlaylistAsync(int PlaylistId)
        {
            return await db.Routes.Where(r => r.PlaylistModelId == PlaylistId).ToListAsync();
        }

        public async Task<List<string>> GetPlaylistNamesAsync()
        {
            return await db.Playlists.Select(p => p.Name).ToListAsync();
        }
    }
}

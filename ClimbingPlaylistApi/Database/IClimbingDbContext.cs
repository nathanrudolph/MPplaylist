using ClimbingPlaylistApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ClimbingPlaylistApi.Database
{
    public interface IClimbingDbContext : IDisposable
    {
        DbSet<PlaylistModel> Playlists { get; set; }
        DbSet<RouteModel> Routes { get; set; }

        int SaveChanges();
    }
}
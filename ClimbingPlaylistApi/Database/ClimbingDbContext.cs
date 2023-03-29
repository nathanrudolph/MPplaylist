using Microsoft.EntityFrameworkCore;
using ClimbingPlaylistApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingPlaylistApi.Database
{
    internal class ClimbingDbContext : DbContext
    {
        public DbSet<RouteModel> Routes { get; set; }
        public DbSet<PlaylistModel> Playlists { get; set; }

        public string DbPath { get; }

        public ClimbingDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path,"ClimbingPlaylistApi.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }
    }
}
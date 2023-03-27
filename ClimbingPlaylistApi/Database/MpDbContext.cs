using Microsoft.EntityFrameworkCore;
using MPplaylist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPplaylist.Database
{
    internal class MpDbContext : DbContext
    {
        public DbSet<RouteModel> RouteCache { get; set; }

        public string DbPath { get; }

        public MpDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path,"MpApi.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }
    }
}
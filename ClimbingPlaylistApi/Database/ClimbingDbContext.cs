﻿using Microsoft.EntityFrameworkCore;
using ClimbingPlaylistApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace ClimbingPlaylistApi.Database
{
    public class ClimbingDbContext : DbContext
    {
        public virtual DbSet<RouteModel> Routes { get; set; }
        public virtual DbSet<PlaylistModel> Playlists { get; set; }

        public ClimbingDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
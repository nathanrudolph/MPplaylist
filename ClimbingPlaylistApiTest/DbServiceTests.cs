using ClimbingPlaylistApi.Database;
using ClimbingPlaylistApi.Models;
using ClimbingPlaylistApi.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace ClimbingPlaylistApiTest
{
    public class DbServiceTests
    {
        private readonly DbService _sut;
        private readonly ClimbingDbContext _context;
        private readonly DbContextOptionsBuilder _optionsBuilder;

        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClimbingPlaylistApi;Integrated Security=True;";

        public DbServiceTests()
        {
            _optionsBuilder = new DbContextOptionsBuilder();
            _optionsBuilder.UseSqlServer(_connectionString);
            _context = new ClimbingDbContext(_optionsBuilder.Options);
            _sut = new DbService(_context);
        }

        [Fact]
        public void DbService_ShouldAddRoute()
        {
            RouteModel expectedRoute = new RouteModel("Armatron", "105809181", "https://www.mountainproject.com/route/105809181/armatron");

            _sut.AddRoute(expectedRoute);

            var routes = _sut.GetAllRoutes();

            routes.Should().Contain(expectedRoute);

            _sut.RemoveRoute(expectedRoute);

            routes = _sut.GetAllRoutes();

            routes.Should().NotContain(expectedRoute);
        }
    }
}

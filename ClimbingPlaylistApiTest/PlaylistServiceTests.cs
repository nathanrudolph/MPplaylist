using ClimbingPlaylistApi.Database;
using ClimbingPlaylistApi.Domain;
using ClimbingPlaylistApi.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using MpScraper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ClimbingPlaylistApiTest;

public class PlaylistServiceTests
{
    private readonly PlaylistService _sut;
    private readonly IDbService _dbService;
    private readonly ClimbingDbContext _context;
    private readonly DbContextOptionsBuilder _optionsBuilder;
    private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClimbingPlaylistApi;Integrated Security=True;";
    private readonly IRouteModelHandler _routeModelHandler;
    private readonly IMpScraperAdapter _mpScraperAdapter;
    private readonly IMpScraper _mpScraper;

    public PlaylistServiceTests()
    {
        _optionsBuilder = new DbContextOptionsBuilder();
        _optionsBuilder.UseSqlServer(_connectionString);
        _context = new ClimbingDbContext(_optionsBuilder.Options);
        _dbService = new DbService(_context);
        _mpScraper = new MpScraper.MpScraper();
        _mpScraperAdapter = new MpScraperAdapter(_mpScraper);
        _routeModelHandler = new RouteModelHandler(_dbService, _mpScraperAdapter);
        _sut = new PlaylistService(_dbService,_routeModelHandler);
    }

    [Fact]
    public async Task PlaylistService_ShouldCreateNewPlaylist()
    {
        int newPlaylistId = await _sut.AddNewEmptyPlaylistAsync("endpointTest");

        newPlaylistId.Should().BeGreaterThan(0);
    }
}

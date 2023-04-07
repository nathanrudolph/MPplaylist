using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClimbingPlaylistApi.Models;
using ClimbingPlaylistApi.Services;
using Moq;
using Xunit;
using FluentAssertions;
using ClimbingPlaylistApi.Domain;

namespace ClimbingPlaylistApiTest
{
    public class RouteModelGeneratorTests
    {
        private readonly RouteModelHandler _sut;
        private readonly Mock<IDbService> _dbServiceMock = new Mock<IDbService>();
        private readonly Mock<IMpScraper> _mpScraperMock = new Mock<IMpScraper>();

        public RouteModelGeneratorTests() 
        {
            _sut = new RouteModelHandler(_dbServiceMock.Object,_mpScraperMock.Object);
        }

        [Fact]
        public void RouteModelGenerator_ShouldBuildRoute_IfInDb()
        {
            //Arrange
            RouteModel expectedRoute = new RouteModel()
            { Name = "Armatron", MpId = "105809181", Url = "https://www.mountainproject.com/route/105809181/armatron" };
            _dbServiceMock.Setup(x => x.GetRouteByMpIdAsync("105809181").Result)
                .Returns(expectedRoute);

            //Act
            var result = _sut.GetRoute("https://www.mountainproject.com/route/105809181/armatron");

            //Assert
            result.Should().Be(expectedRoute);
        }

        [Fact]
        public void RouteModelGenerator_ShouldBuildRoute_IfNotInDb()
        {
            //Arrange
            RouteModel expectedRoute = new RouteModel()
            { Name = "Armatron", MpId = "105809181", Url = "https://www.mountainproject.com/route/105809181/armatron" };
            _dbServiceMock.Setup(x => x.GetRouteByMpIdAsync("105809181").Result)
                .Returns<RouteModel?>(null);
            _mpScraperMock.Setup(x =>
                x.GetRouteFromUrl("https://www.mountainproject.com/route/105809181/armatron"))
                .Returns(expectedRoute);

            //Act
            var result = _sut.GetRoute("https://www.mountainproject.com/route/105809181/armatron");

            //Assert
            result.Should().Be(expectedRoute);
        }
    }
}

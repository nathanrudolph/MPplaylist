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

namespace ClimbingPlaylistApiTest
{
    public class RouteModelGeneratorTests
    {
        private readonly RouteModelGenerator _sut;
        private readonly Mock<IDbService> _dbServiceMock = new Mock<IDbService>();

        public RouteModelGeneratorTests() 
        {
            _sut = new RouteModelGenerator(_dbServiceMock.Object);
        }

        [Fact]
        public void RouteModelGenerator_ShouldBuildRoute_IfInDb()
        {
            //Arrange
            RouteModel expectedRoute = new RouteModel("Armatron", (uint)105809181, "https://www.mountainproject.com/route/105809181/armatron");
            _dbServiceMock.Setup(x => x.GetRoute((uint)105809181)).Returns(expectedRoute);

            //Act
            var result = _sut.Generate("https://www.mountainproject.com/route/105809181/armatron");

            //Assert
            result.Should().Be(expectedRoute);
        }

        [Fact]
        public void RouteModelGenerator_ShouldBuildRoute_IfNotInDb()
        {
            //Arrange
            RouteModel expectedRoute = new RouteModel("Armatron", (uint)105809181, "https://www.mountainproject.com/route/105809181/armatron")
            {
            };
            _dbServiceMock.Setup(x => x.GetRoute((uint)105809181)).Returns(new RouteModel("",0,""));

            //Act
            var result = _sut.Generate("https://www.mountainproject.com/route/105809181/armatron");

            //Assert
            result.Name.Should().Be(expectedRoute.Name);
            result.Id.Should().Be(expectedRoute.Id);
        }
    }
}

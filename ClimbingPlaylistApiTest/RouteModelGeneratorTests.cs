using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClimbingPlaylistApi.Models;
using Xunit;

namespace ClimbingPlaylistApiTest
{
    public class RouteModelGeneratorTests
    {
        private RouteModelGenerator _sut;

        public RouteModelGeneratorTests() 
        {
            _sut = new RouteModelGenerator();
        }

        [Fact]
        public void RouteModelGeneratorShouldBuildRoute()
        {
            var result = _sut.Generate("https://www.mountainproject.com/route/105809181/armatron");
        }
    }
}

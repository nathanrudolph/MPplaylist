using ClimbingPlaylistApi.Services;
using ClimbingPlaylistApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ClimbingPlaylistApiTest
{
    public class MpScraperTest
    {
        [Fact]
        public void MpScraper_IsTest()
        {
            //Arrange
            string url = "https://www.mountainproject.com/route/105920684/the-nightcrawler";
            RouteModel result;

            //Act
            result = MpScraper.GetRouteFromUrl(url);

            //Assert
            Assert.True("The Nightcrawler" == result.Name);
        }
    }
}

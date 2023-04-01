using ClimbingPlaylistApi.Services;
using ClimbingPlaylistApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace ClimbingPlaylistApiTest
{
    public class MpScraperTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void MpScraper_ShouldScrapeRoute(string expectedName, uint expectedId, string urlToScrape)
        {
            //Arrange
            MpScraper scraper = new MpScraper();
            RouteModel result;

            //Act
            result = scraper.GetRouteFromUrl(urlToScrape);

            //Assert
            result.Name.Should().Be(expectedName);
            result.Id.Should().Be(expectedId);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { "The Nightcrawler", (uint)105920684 , "https://www.mountainproject.com/route/105920684/the-nightcrawler" };
            yield return new object[] { "Armatron", (uint)105809181 , "https://www.mountainproject.com/route/105809181/armatron" };
        }
    }
}

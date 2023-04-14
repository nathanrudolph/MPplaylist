using ClimbingPlaylistApi.Services;
using ClimbingPlaylistApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using ClimbingPlaylistApi.Domain;
using MpScraper;

namespace ClimbingPlaylistApiTest
{
    public class MpScraperTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void MpScraper_ShouldScrapeRoute(string expectedName, string expectedId, string urlToScrape)
        {
            //Arrange
            IMpScraper _mpScraper = new MpScraper.MpScraper();
            MpScraperAdapter scraper = new MpScraperAdapter(_mpScraper);
            RouteModel? result;

            //Act
            result = scraper.GetRouteModelFromUrl(urlToScrape);

            //Assert
            result.Should().NotBeNull();
            result!.Name.Should().Be(expectedName);
            result.MpId.Should().Be(expectedId);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public async Task MpScraper_ShouldScrapeRouteAsync(string expectedName, string expectedId, string urlToScrape)
        {
            //Arrange
            IMpScraper _mpScraper = new MpScraper.MpScraper();
            MpScraperAdapter scraper = new MpScraperAdapter(_mpScraper);
            RouteModel? result;

            //Act
            result = await scraper.GetRouteModelFromUrlAsync(urlToScrape);

            //Assert
            result.Should().NotBeNull();
            result!.Name.Should().Be(expectedName);
            result.MpId.Should().Be(expectedId);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { "The Nightcrawler", "105920684" , "https://www.mountainproject.com/route/105920684/the-nightcrawler" };
            yield return new object[] { "Armatron", "105809181" , "https://www.mountainproject.com/route/105809181/armatron" };
        }
    }
}

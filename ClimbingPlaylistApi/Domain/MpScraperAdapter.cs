using ClimbingPlaylistApi.Models;
using Microsoft.AspNetCore.Routing;
using MpScraper;
using System.Text.Json;

namespace ClimbingPlaylistApi.Domain
{
    public class MpScraperAdapter : IMpScraperAdapter
    {
        public MpScraperAdapter(IMpScraper MpScraper)
        {
            _scraper = MpScraper;
        }

        private readonly IMpScraper _scraper;

        public RouteModel? GetRouteModelFromUrl(string url)
        {
            _scraper.ScrapeRouteFromUrl(url);
            if (_scraper.Name == null || _scraper.MpId == null || _scraper.Url == null)
            {
                return null;
            }
            return new RouteModel()
            {
                Name = _scraper.Name,
                MpId = _scraper.MpId,
                Url = _scraper.Url,
                Height = _scraper.Height,
                Grade = _scraper.Grade,
                Type = _scraper.Type,
                Description = _scraper.Description,
                Rating = _scraper.Rating,
                Popularity = _scraper.Popularity
            };
        }

        public async Task<RouteModel?> GetRouteModelFromUrlAsync(string url)
        {
            await _scraper.ScrapeRouteFromUrlAsync(url);
            if (_scraper.Name == null || _scraper.MpId == null || _scraper.Url == null)
            {
                return null;
            }
            return new RouteModel()
            {
                Name = _scraper.Name,
                MpId = _scraper.MpId,
                Url = _scraper.Url,
                Height = _scraper.Height,
                Grade = _scraper.Grade,
                Type = _scraper.Type,
                Description = _scraper.Description,
                Rating = _scraper.Rating,
                Popularity = _scraper.Popularity
            };
        }
    }
}

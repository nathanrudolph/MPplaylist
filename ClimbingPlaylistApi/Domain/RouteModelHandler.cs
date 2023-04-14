using ClimbingPlaylistApi.Database;
using ClimbingPlaylistApi.Models;
using ClimbingPlaylistApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingPlaylistApi.Domain
{
    /// <summary>
    /// Class to handle db retreival/web scraping of climbing routes
    /// </summary>
    public class RouteModelHandler : IRouteModelHandler
    {
        public RouteModelHandler(IDbService dbService, IMpScraperAdapter mpScraperAdapter)
        {
            _dbService = dbService;
            _mpScraperAdapter = mpScraperAdapter;
        }

        private readonly IDbService _dbService;
        private readonly IMpScraperAdapter _mpScraperAdapter;

        /// <summary>
        /// Returns a RouteModel object for a given MP URL. Will scrape from web if route is not already in db.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<RouteModel?> GetRoute(string url)
        {
            RouteUrl routeUrl = new RouteUrl(url);
            string MpId = routeUrl.GetRouteId();
            var route = await _dbService.GetRouteByMpIdAsync(MpId);
            if (route == null)
            {
                route = await _mpScraperAdapter.GetRouteModelFromUrlAsync(url);
            }
            return route;
        }
    }
}

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
        public RouteModelHandler(IDbService dbService, IMpScraper mpScraper)
        {
            _dbService = dbService;
            _mpScraper = mpScraper;
        }

        private IDbService _dbService;
        private IMpScraper _mpScraper;

        /// <summary>
        /// Returns a RouteModel object for a given MP URL. Will scrape from web if route is not already in db.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public RouteModel GetRoute(string url)
        {
            RouteUrl routeUrl = new RouteUrl(url);
            string MpId = routeUrl.GetRouteId();
            var route = _dbService.GetRoute(MpId).Result;
            if (route == null)
            {
                route = GetRouteFromScraper(url);
            }
            return route;
        }

        private RouteModel GetRouteFromScraper(string url)
        {
            var route = _mpScraper.GetRouteFromUrl(url);
            return route;
        }
    }
}

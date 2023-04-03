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
        /// Returns a RouteModel object for a given MP URL. Will scrape from web and add to db if route is not in db.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public RouteModel GetRoute(string url)
        {
            RouteUrl routeUrl = new RouteUrl(url);
            uint id = routeUrl.GetRouteId();
            var route = GetRouteFromDb(id);
            if (route.MpId == 0)
            {
                route = GetRouteFromScraper(url);
                SaveRouteToDb(route);
            }
            return route;
        }

        private RouteModel GetRouteFromDb(uint id)
        {
            RouteModel route;
            try
            {
                route = _dbService.GetRoute(id);
            }
            catch
            {
                route = new RouteModel("", 0, "");
            }
            return route;
        }

        private RouteModel GetRouteFromScraper(string url)
        {
            var route = _mpScraper.GetRouteFromUrl(url);
            SaveRouteToDb(route);
            return route;
        }

        private void SaveRouteToDb(RouteModel routeModel)
        {
            _dbService.AddRoute(routeModel);
        }
    }
}

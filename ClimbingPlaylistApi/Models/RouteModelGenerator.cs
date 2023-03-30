using ClimbingPlaylistApi.Models;
using ClimbingPlaylistApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingPlaylistApi.Models
{
    /// <summary>
    /// Class to build a RouteModel
    /// </summary>
    public class RouteModelGenerator
    {
        public RouteModelGenerator() 
        {
            //pass in DbContext/DbService, or DI container, or delegate to add route to db
        }

        /// <summary>
        /// Generates a RouteModel object for a given MP URL. Will only scrape from web if route is not already in db.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public RouteModel Generate(string url)
        {
            RouteUrl routeUrl = new RouteUrl(url);
            uint id = routeUrl.GetRouteId();
            var route = GetRouteFromDb(id);
            if (route.Id == 0)
            {
                route = GetRouteFromScraper(url);
            }
            return route;
        }

        private RouteModel GetRouteFromDb(uint id) 
        {
            throw new NotImplementedException();
            // query route from db

            // if not found, generate new route with id=0
        }

        private RouteModel GetRouteFromScraper(string url)
        {
            var route = MpScraper.GetRouteFromUrl(url);
            SaveRouteToDb(route);
            return route;
        }

        private void SaveRouteToDb(RouteModel routeModel)
        {
            throw new NotImplementedException();
        }
    }
}

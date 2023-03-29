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
    public static class RouteModelGenerator
    {
        //pass in DbContext or delegate to add route to db

        /// <summary>
        /// Generates a RouteModel object for a given MP URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static RouteModel Generate(string url)
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

        private static RouteModel GetRouteFromDb(uint id) 
        {
            throw new NotImplementedException();
            // query route from db

            // if not found, generate new route with id=0
        }

        private static RouteModel GetRouteFromScraper(string url)
        {
            var route = MpScraper.GetRouteFromUrl(url);
            SaveRouteToDb(route);
            return route;
        }

        private static void SaveRouteToDb(RouteModel routeModel)
        {
            throw new NotImplementedException();
        }
    }
}

using System.Reflection.Emit;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MountainProjectAPI;
using ClimbingPlaylistApi.Models;

namespace ClimbingPlaylistApi.Services
{
    /// <summary>
    /// Wrapper for scraper from separate MountainProjectAPI: https://github.com/derekantrican/MountainProject
    /// </summary>
    public class MpScraper : IMpScraper
    {
        //Note that this class is a wrapper for a separate open-source library, class names from that project shouldn't creep outside this class
        public RouteModel GetRouteFromUrl(string url)
        {
            if (string.IsNullOrEmpty(url) || !url.Contains("route"))
            {
                throw new ArgumentException("Url is not a valid MP route page.");
            }
            if (!MountainProjectAPI.Url.Contains(url, Utilities.MPBASEURL))
            {
                url = MountainProjectAPI.Url.BuildFullUrl(Utilities.MPBASEURL + url);
            }
            MountainProjectAPI.Route route = new MountainProjectAPI.Route();
            route = new MountainProjectAPI.Route { ID = Utilities.GetID(url) };
            Parsers.ParseRouteAsync(route, false).Wait();

            return BuildRouteModelFromScrapedRoute(route);
        }

        private RouteModel BuildRouteModelFromScrapedRoute(MountainProjectAPI.Route route)
        {
            return new RouteModel(route.Name, route.ID, route.URL)
            {
                Height = (int?)route.Height.GetValue(Dimension.Units.Feet),
                Grade = route.GetRouteGrade().ToString(),
                Type = route.TypeString,
                Description = route.AdditionalInfo,
                Rating = route.Rating,
                Popularity = route.Popularity
            };
        }
    }
}
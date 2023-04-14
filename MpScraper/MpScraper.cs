using System.Reflection.Emit;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MountainProjectAPI;
using System.Text.Json;

namespace MpScraper
{
    /// <summary>
    /// Wrapper for scraper from separate MountainProjectAPI: https://github.com/derekantrican/MountainProject
    /// </summary>
    public class MpScraper : IMpScraper
    {
        //Note that this class is a wrapper for a separate open-source library, class names from that project shouldn't creep outside this class

        /// <summary>
        /// Returns a json string for route details of a given object
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public void ScrapeRouteFromUrl(string url)
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

            SetPropertiesToExpose(route);
        }

        public async Task ScrapeRouteFromUrlAsync(string url)
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
            await Parsers.ParseRouteAsync(route, false);

            SetPropertiesToExpose(route);
        }

        private void SetPropertiesToExpose(MountainProjectAPI.Route route)
        {
            this.Name = route.Name;
            this.MpId = route.ID;
            this.Url = route.URL;
            this.Height = (int?)route.Height.GetValue(Dimension.Units.Feet);
            this.Grade = route.GetRouteGrade().ToString();
            this.Type = route.TypeString;
            this.Description = route.AdditionalInfo;
            this.Rating = route.Rating;
            this.Popularity = route.Popularity;
        }

        public string? Name { get; private set; }
        public string? MpId { get; private set; }
        public string? Url { get; private set; }
        public string? Type { get; private set; }
        public string? Description { get; private set; }
        public string? Grade { get; private set; }
        public double? Rating { get; private set; }
        public int? Height { get; private set; }
        public int? Popularity { get; private set; }
    }
}
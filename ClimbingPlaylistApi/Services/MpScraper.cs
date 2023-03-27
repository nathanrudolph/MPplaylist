using System.Reflection.Emit;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MountainProjectAPI;

namespace ClimbingPlaylistApi.Services
{
    public class MpScraper
    {
        public List<string> Urls { get; set; }
        public List<Route> Routes { get; set; }

        public MpScraper()
        {
            Urls = new List<string>();
            Routes = new List<Route>();
        }

        public void AddUrl(string inputURL)
        {
            Urls.Add(inputURL);
        }

        public async Task GetRoutesFromURLsAsync()
        {
            var tasks = new List<Task>();
            foreach (string url in Urls)
            {
                Route current = await GetRouteFromUrlAsync(url);
                Routes.Add(current);
            }
        }

        private async Task<Route> GetRouteFromUrlAsync(string inputURL)
        {
            if (string.IsNullOrEmpty(inputURL) || !inputURL.Contains("route"))
            {
                throw new ArgumentException();
            }
            if (!MountainProjectAPI.Url.Contains(inputURL, Utilities.MPBASEURL))
            {
                inputURL = MountainProjectAPI.Url.BuildFullUrl(Utilities.MPBASEURL + inputURL);
            }
            Route route = new Route();
            route = new Route { ID = Utilities.GetID(inputURL) };
            Parsers.ParseRouteAsync(route).Wait();
            return route;
        }
    }
}
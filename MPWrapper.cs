using System.Reflection.Emit;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MountainProjectAPI;

namespace MPplaylist
{
    public class MPWrapper
    {
        public List<string> Urls {get;set;}
        public List<Route> Routes {get; set;}

        public MPWrapper()
        {
            this.Urls = new List<string>();
            this.Routes = new List<Route>();
        }

        public void AddUrl(string inputURL)
        {
            this.Urls.Add(inputURL);
        }

        public async Task GetRoutesFromURLsAsync()
        {
            var tasks = new List<Task>();
            foreach (string url in this.Urls)
            {
                Route current = await GetRouteFromUrlAsync(url);
                Routes.Add(current);
            }
        }

        private async Task<Route> GetRouteFromUrlAsync(string inputURL)
        {
            if (String.IsNullOrEmpty(inputURL) || !inputURL.Contains("route"))
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
using System.Diagnostics;
// See https://aka.ms/new-console-template for more information
using MountainProjectAPI;
namespace MPplaylist
{
    class Program
    {
        static void Main(string[] args)
        {
            string nightcrawlerURL = "https://www.mountainproject.com/route/105920684/the-nightcrawler";
            
            MPWrapper mpWrapper = new MPWrapper();
            mpWrapper.AddUrl(nightcrawlerURL);
            Stopwatch watch = new Stopwatch();
            watch.Start();
            mpWrapper.GetRoutesFromURLsAsync();
            watch.Stop();
            Console.WriteLine(watch.Elapsed);
            List<Route> routes = mpWrapper.Routes;
            
            foreach (var route in routes)
            {
                Console.WriteLine(route.Name);
            }
            Console.WriteLine("Complete.");
        }
    }
}
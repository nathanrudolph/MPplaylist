using System.Diagnostics;
using MountainProjectAPI;
using MPplaylist.Database;
using MPplaylist.Models;

namespace MPplaylist
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new MpDbContext();

            Console.WriteLine($"Database path: {db.DbPath}.");

            db.Add(new RouteModel("The NightCrawler", 105920684, "https://www.mountainproject.com/route/105920684/the-nightcrawler"));
            db.SaveChanges();

            var route = db.RouteCache.OrderBy(x => x.Name).First();

            route.Name = "The Day Man";
            db.SaveChanges();

            //db.Remove(route);
            //db.SaveChanges();



            //string nightcrawlerURL = "https://www.mountainproject.com/route/105920684/the-nightcrawler";

            //MPWrapper mpWrapper = new MPWrapper();
            //mpWrapper.AddUrl(nightcrawlerURL);
            //Stopwatch watch = new Stopwatch();
            //watch.Start();
            //mpWrapper.GetRoutesFromURLsAsync();
            //watch.Stop();
            //Console.WriteLine(watch.Elapsed);
            //List<Route> routes = mpWrapper.Routes;

            //foreach (var route in routes)
            //{
            //    Console.WriteLine(route.Name);
            //}
            //Console.WriteLine("Complete.");
        }
    }
}
using ClimbingPlaylistApi.Models;

namespace ClimbingPlaylistApi.Services
{
    public interface IMpScraper
    {
        RouteModel GetRouteFromUrl(string url);
    }
}
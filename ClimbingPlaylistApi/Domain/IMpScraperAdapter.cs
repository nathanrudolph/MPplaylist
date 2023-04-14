using ClimbingPlaylistApi.Models;

namespace ClimbingPlaylistApi.Domain
{
    public interface IMpScraperAdapter
    {
        RouteModel? GetRouteModelFromUrl(string url);
        Task<RouteModel?> GetRouteModelFromUrlAsync(string url);
    }
}
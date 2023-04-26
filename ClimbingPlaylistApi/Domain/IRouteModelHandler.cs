using ClimbingPlaylistApi.Models;

namespace ClimbingPlaylistApi.Domain
{
    public interface IRouteModelHandler
    {
        Task<RouteModel?> GetRoute(string url);
    }
}
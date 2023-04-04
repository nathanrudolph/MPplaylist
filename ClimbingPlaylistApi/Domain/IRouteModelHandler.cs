using ClimbingPlaylistApi.Models;

namespace ClimbingPlaylistApi.Domain
{
    public interface IRouteModelHandler
    {
        RouteModel GetRoute(string url);
    }
}
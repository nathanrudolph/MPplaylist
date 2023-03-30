using ClimbingPlaylistApi.Models;

namespace ClimbingPlaylistApi.Database
{
    public interface IRouteRepository
    {
        void Add(RouteModel route);
        void Remove(RouteModel route);
        RouteModel Get(uint id);
        void Update(uint id, RouteModel route);
    }
}

using ClimbingPlaylistApi.Database;
using ClimbingPlaylistApi.Models;

namespace ClimbingPlaylistApi.Services
{
    public class DbService
    {
        public DbService() 
        {
            climbingDbContext = new ClimbingDbContext();
        }

        private ClimbingDbContext climbingDbContext;

        public void AddRouteToPlaylist(RouteModel route, PlaylistModel playlist)
        {
            throw new NotImplementedException();
        }

        public void RemoveRouteFromPlaylist(RouteModel route, PlaylistModel playlist)
        {
            throw new NotImplementedException();
        }

        public void AddNewPlaylist(PlaylistModel playlist)
        {

        }

        public void UpdatePlaylist(PlaylistModel playlist)
        {
            throw new NotImplementedException();
        }
    }
}

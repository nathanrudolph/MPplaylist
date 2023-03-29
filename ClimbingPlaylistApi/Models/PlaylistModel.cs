using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingPlaylistApi.Models
{
    /// <summary>
    /// Model for a group of climbing routes
    /// </summary>
    public class PlaylistModel : IPlaylistModel
    {
        public PlaylistModel(string name = "New List")
        {
            Id = 0; //TODO: generate/validate primary key, or handle in PlaylistService
            Name = name;
            Routes = new List<RouteModel>();
        }

        /// <summary>
        /// Primary key of the playlist
        /// </summary>
        public int Id { get; init; }
        public string Name { get; set; }
        private List<RouteModel> Routes { get; set; }

        public void Add(RouteModel route)
        {
            if (Routes.Any(r => r.Id == route.Id))
            {
                var message = $"Route \"{route.Name}\" is already in this playlist.";
                throw new ArgumentException(message);
            }
            Routes.Add(route);
        }

        public RouteModel GetRoute(int id)
        {
            try
            {
                return Routes.FirstOrDefault(r => r.Id == id);
            }
            catch(NullReferenceException)
            {
                var message = $"Route {id} was not found in the playlist.";
                throw new KeyNotFoundException(message);
            }       
        }

        public List<RouteModel> GetAllRoutes()
        {
            return Routes;
        }

        public void Remove(RouteModel route)
        {
            if (!Routes.Any(r => r.Id == route.Id))
            {
                var message = $"Route \"{route.Name}\" was not found.";
                throw new ArgumentException(message);
            }
            Routes.Remove(route);
        }

        /// <summary>
        /// Rename the playlist
        /// </summary>
        /// <param name="newName"></param>
        public void Rename(string newName)
        {
            //TODO: check if new playlist name already exists
            Name = newName;
        }
    }
}

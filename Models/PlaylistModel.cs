using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPplaylist.Models
{
    public class PlaylistModel : IPlaylistModel
    {
        public PlaylistModel(string name = "New List")
        {
            Id = 0; //TODO: generate/validate primary key
            Name = name;
            Routes = new List<RouteModel>();
        }

        public int Id { get; init; }
        public string Name { get; set; }
        public List<RouteModel> Routes { get; set; }

        public void Add(RouteModel route)
        {
            if (Routes.Any(r => r.Id == route.Id))
            {
                var message = $"Route \"{route.Name}\" is already in this playlist.";
                throw new ArgumentException(message);
            }

            Routes.Add(route);
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

        public void Rename(string newName)
        {
            //TODO: check if new playlist name already exists
            Name = newName;
        }
    }
}

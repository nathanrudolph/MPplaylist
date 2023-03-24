using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPplaylist.Models
{
    public class RoutePlaylistModel : IRoutePlaylistModel
    {
        public RoutePlaylistModel(string name = "New List")
        {
            Id = 0; //TODO: generate/validate unique Id
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
                //TODO: add error logging
                return;
            }

            Routes.Add(route);
        }

        public void Remove(RouteModel route)
        {
            if (!Routes.Any(r => r.Id == route.Id))
            {
                //TODO: add error logging
                return;
            }
            Routes.Remove(route);
        }

        public void Rename(string newName)
        {
            Name = newName;
        }
    }
}

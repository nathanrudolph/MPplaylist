using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingPlaylistApi.Models
{
    /// <summary>
    /// Model for a list of climbing routes
    /// </summary>
    public class PlaylistModel
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
        public List<RouteModel> Routes { get; set; }
    }
}

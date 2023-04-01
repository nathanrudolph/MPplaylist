using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingPlaylistApi.Models
{
    /// <summary>
    /// Model for an individual climbing route
    /// </summary>
    public class RouteModel : IRouteModel
    {
        //TODO: switch to record
        public RouteModel(string name, uint id, string url)
        {
            this.Name = name;
            this.Id = id;
            this.Url = url;
            Playlists = new List<PlaylistModel>();
        }
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        /// <summary>
        /// Climbing types of the route (Sport, Trad, etc) joined in a single string
        /// </summary>
        public string? Type { get; set; }
        public string? Description { get; set; }
        /// <summary>
        /// Climbing grade in YDS
        /// </summary>
        public string? Grade { get; set; }
        /// <summary>
        /// Average user rating of the climb on a scale from 0-4
        /// </summary>
        public double? Rating { get; set; }
        /// <summary>
        /// Route length in feet
        /// </summary>
        public int? Height { get; set; }
        public int? Popularity { get; set; }

        public List<PlaylistModel> Playlists { get; set; }
    }
}

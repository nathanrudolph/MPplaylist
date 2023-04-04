using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingPlaylistApi.Models
{
    /// <summary>
    /// Model for an individual climbing route
    /// </summary>
    public class RouteModel
    {
        //TODO: switch to record?

        public RouteModel(string name, string MpId, string url)
        {
            this.Name = name;
            this.MpId = MpId;
            this.Url = url;
            //Playlists = new List<PlaylistModel>();
        }
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// ID Key in MP Url
        /// </summary>
        [MaxLength(64)]
        public string MpId { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        /// <summary>
        /// MP Url of the route
        /// </summary>
        [MaxLength(1024)]
        public string Url { get; set; }

        /// <summary>
        /// Climbing types of the route (Sport, Trad, etc) joined in a single string
        /// </summary>
        [MaxLength(64)]
        public string? Type { get; set; }
        
        [MaxLength(4096)]
        public string? Description { get; set; }

        /// <summary>
        /// Climbing grade in YDS
        /// </summary>
        [MaxLength(16)]
        public string? Grade { get; set; }

        /// <summary>
        /// Average user rating of the climb on a scale from 0-4
        /// </summary>
        [MaxLength(8)]
        public double? Rating { get; set; }

        /// <summary>
        /// Route length in feet
        /// </summary>
        [MaxLength(8)]
        public int? Height { get; set; }

        [MaxLength(8)]
        public int? Popularity { get; set; }

        // // Hold list of playlists that contain this route to create a many-to-many link
        //public List<PlaylistModel> Playlists { get; set; }
    }
}

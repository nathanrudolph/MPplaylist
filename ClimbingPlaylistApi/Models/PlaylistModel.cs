using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            Name = name;
            Routes = new List<RouteModel>();
        }

        [Key]
        public int Id { get; init; }
        public string Name { get; set; }
        public List<RouteModel> Routes { get; set; }
    }
}

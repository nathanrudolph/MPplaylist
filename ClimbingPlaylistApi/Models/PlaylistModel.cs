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
            CreationDate = DateTime.Now;
        }

        [Key]
        public int Id { get; init; }
        
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
        
        public List<RouteModel> Routes { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(256)]
        public required string Name { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreationDate { get; set; } = DateTime.Now;
        
        public List<RouteModel> Routes { get; set; } = new List<RouteModel>();
    }
}

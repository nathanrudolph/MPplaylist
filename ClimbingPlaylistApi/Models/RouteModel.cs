using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
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
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public required string Name { get; set; }

        /// <summary>
        /// ID Key in MP Url
        /// </summary>
        [Required]
        [MaxLength(64)]
        public required string MpId { get; set; }

        /// <summary>
        /// MP Url of the route
        /// </summary>
        [Required]
        [MaxLength(1024)]
        public required string Url { get; set; }

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

        [ForeignKey(nameof(PlaylistModel))]
        public int PlaylistModelId { get; set; }
    }
}

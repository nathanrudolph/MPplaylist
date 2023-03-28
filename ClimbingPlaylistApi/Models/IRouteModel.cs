using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPplaylist.Models
{
    /// <summary>
    /// Interface for a climbing route model.
    /// </summary>
    public interface IRouteModel
    {
        uint Id { get; set; }
        string Name { get; set; }
        string Url { get; set; }
        string? Type { get; set; }
        string? Description { get; set; }
        string? Grade { get; set; }
        double? Rating { get; set; }
        int? Height { get; set; }
        int? Popularity { get; set; }

        //TODO: add validator for Id/Name/Url
    }
}

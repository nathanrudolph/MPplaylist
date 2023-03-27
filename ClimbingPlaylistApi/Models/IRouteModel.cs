using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPplaylist.Models
{
    public interface IRouteModel
    {
        int Id { get; set; }
        string Name { get; set; }
        string Url { get; set; }
        string? Type { get; set; }
        string? Description { get; set; }
        string? Grade { get; set; }
        double? Rating { get; set; }
        string? Area { get; set; }
        int? Height { get; set; }

        //TODO: add validator for Id/Name/Url
    }
}

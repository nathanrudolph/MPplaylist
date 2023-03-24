using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPplaylist.Models
{
    public interface IRouteModel
    {
        string Name { get; init; }
        string Id { get; init; }
        string Url { get; init; }
        string? Type { get; init; }
        string? Description { get; init; }
        string? Grade { get; init; }
        double? Rating { get; init; }
        string? Area { get; init; }
        int? Height { get; init; }
    }
}

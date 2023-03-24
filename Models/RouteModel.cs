using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPplaylist.Models
{
    public struct RouteModel : IRouteModel
    {
        public string Name { get; init; }
        public string Id { get; init; }
        public string Url { get; init; }
        public string? Type { get; init; }
        public string? Description { get; init; }
        public string? Grade { get; init; }
        public double? Rating { get; init; }
        public string? Area { get; init; }
        public int? Height { get; init; }
    }
}

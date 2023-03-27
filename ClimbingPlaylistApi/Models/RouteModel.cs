using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPplaylist.Models
{
    public class RouteModel : IRouteModel
    {
        public RouteModel(string name, int id, string url)
        {
            this.Name = name;
            this.Id = id;
            this.Url = url;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public string? Grade { get; set; }
        public double? Rating { get; set; }
        public string? Area { get; set; }
        public int? Height { get; set; }

        //TODO: switch to record
    }
}

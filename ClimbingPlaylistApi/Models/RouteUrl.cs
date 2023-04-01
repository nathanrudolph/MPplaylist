namespace ClimbingPlaylistApi.Models
{
    public class RouteUrl : IRouteUrl
    {
        public RouteUrl(string url)
        {
            this.Url = url;
            this.Uri = new Uri(url);
            ValidateUrl(url);
        }

        private string Url { get; set; }

        private Uri Uri { get; set; }

        public override string ToString()
        {
            return Url;
        }

        public uint GetRouteId()
        {
            if (Url == "") { return 0; }
            string id = Uri.Segments[2].Remove(Uri.Segments[2].Length - 1);
            return uint.Parse(id);
        }

        private void ValidateUrl(string url)
        {
            //TODO: Url validation
            if (Uri.Segments.Length != 4 | !Uri.Segments[1].Contains("route"))
            {
                Url = "";
                Uri = new Uri("");
                throw new ArgumentException(url);
            }
        }
    }
}

namespace ClimbingPlaylistApi.Domain
{
    public class RouteUrl : IRouteUrl
    {
        public RouteUrl(string url)
        {
            Url = url;
            Uri = new Uri(url);
            ValidateUrl(url);
        }

        private string Url { get; set; }

        private Uri Uri { get; set; }

        public override string ToString()
        {
            return Url;
        }

        public string GetRouteId()
        {
            if (Url == "") { return ""; }
            string MpId = Uri.Segments[2].Remove(Uri.Segments[2].Length - 1);
            return MpId;
        }

        private void ValidateUrl(string url)
        {
            //TODO: more Url validation
            if (Uri.Segments.Length != 4 | !Uri.Segments[1].Contains("route"))
            {
                Url = "";
                Uri = new Uri("");
                throw new ArgumentException(url);
            }
        }
    }
}

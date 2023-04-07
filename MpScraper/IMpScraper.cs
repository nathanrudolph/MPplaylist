namespace MpScraper
{
    public interface IMpScraper
    {
        void ScrapeRouteFromUrl(string url);
        string? Name { get; }
        string? MpId { get; }
        string? Url { get; }
        string? Type { get; }
        string? Description { get; }
        string? Grade { get; }
        double? Rating { get; }
        int? Height { get; }
        int? Popularity { get; }
    }
}
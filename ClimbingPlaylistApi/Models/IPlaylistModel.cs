namespace MPplaylist.Models
{
    public interface IPlaylistModel
    {
        int Id { get; init; }
        string Name { get; set; }
        List<RouteModel> Routes { get; set; }
        void Add (RouteModel route);
        void Remove (RouteModel route);
        void Rename (string newName);
    }
}
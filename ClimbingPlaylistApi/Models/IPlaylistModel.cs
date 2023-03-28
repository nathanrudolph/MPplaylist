namespace MPplaylist.Models
{
    public interface IPlaylistModel
    {
        int Id { get; init; }
        string Name { get; set; }
        void Add (RouteModel route);
        void Remove (RouteModel route);
        List<RouteModel> GetAllRoutes ();
        RouteModel GetRoute (int id);
        void Rename (string newName);
    }
}
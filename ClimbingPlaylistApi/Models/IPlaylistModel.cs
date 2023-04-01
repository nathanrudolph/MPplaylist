namespace ClimbingPlaylistApi.Models
{
    public interface IPlaylistModel
    {
        int Id { get; init; }
        string Name { get; set; }
        List<RouteModel> Routes { get; set; }

    }
}
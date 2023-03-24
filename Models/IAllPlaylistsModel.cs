namespace MPplaylist.Models
{
    public interface IAllPlaylistsModel
    {
        List<RoutePlaylistModel> Playlists { get; set; }

        void Add (RoutePlaylistModel playlist);
        void Remove (RoutePlaylistModel playlist);
        void GetPlaylistNames();
        void GetPlaylist(string name);
    }
}
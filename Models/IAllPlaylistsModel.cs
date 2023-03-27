namespace MPplaylist.Models
{
    public interface IAllPlaylistsModel
    {
        List<PlaylistModel> Playlists { get; set; }

        void Add (PlaylistModel playlist);
        void Remove (PlaylistModel playlist);
        void GetPlaylistNames();
        void GetPlaylist(string name);
    }
}
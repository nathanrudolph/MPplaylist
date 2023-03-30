using ClimbingPlaylistApi.Models;

namespace ClimbingPlaylistApi.Database
{
    public interface IPlaylistRepository
    {
        void Add(PlaylistModel playlist);
        void Remove(PlaylistModel playlist);
        PlaylistModel Get(int id);
        void Update(int id, PlaylistModel playlist);
    }
}

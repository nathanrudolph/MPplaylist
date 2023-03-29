using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingPlaylistApi.Models
{
    public class AllPlaylistsModel : IAllPlaylistsModel
    {
        public AllPlaylistsModel()
        {
            Playlists = new List<PlaylistModel>();
        }
        public List<PlaylistModel> Playlists { get; set; }

        public void Add(PlaylistModel playlist)
        {
            if (Playlists.Any(p => p.Name == playlist.Name))
            {
                var message = $"Playlist with name \"{playlist.Name}\" already exists.";
                throw new ArgumentException(message);
            }
            Playlists.Add(playlist);
        }

        public void GetPlaylist(string name)
        {
            throw new NotImplementedException();
        }

        public void GetPlaylistNames()
        {
            throw new NotImplementedException();
        }

        public void Remove(PlaylistModel playlist)
        {
            if (!Playlists.Any(p => p.Name == playlist.Name))
            {
                var message = $"Playlist \"{playlist.Name}\" was not found.";
                throw new ArgumentException(message);
            }
            Playlists.Remove(playlist);
        }
    }
}

using MPplaylist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPplaylist
{
    public class PlaylistService : IPlaylistService
    {
        public PlaylistService()
        {
            
        }

        public AllPlaylistsModel PlaylistsModel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public PlaylistModel CurrentPlaylist { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}

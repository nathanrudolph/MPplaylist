using MPplaylist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPplaylist
{
    public interface IPlaylistService
    {
        AllPlaylistsModel PlaylistsModel { get; set; }

        RoutePlaylistModel CurrentPlaylist { get; set; }

        
    }
}

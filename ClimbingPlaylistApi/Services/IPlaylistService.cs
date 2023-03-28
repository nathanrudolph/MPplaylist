using MPplaylist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingPlaylistApi.Services
{
    public interface IPlaylistService
    {
        AllPlaylistsModel PlaylistsModel { get; set; }

        PlaylistModel CurrentPlaylist { get; set; }


    }
}

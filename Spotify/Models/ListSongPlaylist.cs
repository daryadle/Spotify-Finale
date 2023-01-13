using System;
using System.Collections.Generic;

#nullable disable

namespace Spotify.Models
{
    public partial class ListSongPlaylist
    {
        public int PlaylistId { get; set; }
        public int SongId { get; set; }

        public virtual Playlist Playlist { get; set; }
        public virtual Song Song { get; set; }
    }
}

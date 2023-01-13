using System;
using System.Collections.Generic;

#nullable disable

namespace Spotify.Models
{
    public partial class Song
    {
        public Song()
        {
            ListSongPlaylists = new List<ListSongPlaylist>();
        }

        public int SongId { get; set; }
        public string Title { get; set; }
        public int? Duration { get; set; }
        public DateTime? DateOfCreation { get; set; }
        public string Genre { get; set; }
        public int AlbumId { get; set; }
        public int ArtistId { get; set; }

        public virtual Album Album { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual List<ListSongPlaylist> ListSongPlaylists { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace Spotify.Models
{
    public partial class Playlist
    {
        public Playlist()
        {
            ListSongPlaylists = new List<ListSongPlaylist>();
        }

        public int PlaylistId { get; set; }
        public int UserId { get; set; }
        public string Titolo { get; set; }
        public DateTime? DateOfCreation { get; set; }
        public DateTime? DateOfModification { get; set; }

        public virtual User User { get; set; }
        public virtual List<ListSongPlaylist> ListSongPlaylists { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace Spotify.Models
{
    public partial class Album
    {
        public Album()
        {
            Songs = new List<Song>();
        }

        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual List<Song> Songs { get; set; }
    }
}

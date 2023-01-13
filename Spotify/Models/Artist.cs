using System;
using System.Collections.Generic;

#nullable disable

namespace Spotify.Models
{
    public partial class Artist
    {
        public Artist()
        {
            Albums = new List<Album>();
            Songs = new List<Song>();
        }

        public int ArtistId { get; set; }
        public string ArtistName { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}

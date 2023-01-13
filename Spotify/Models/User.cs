using System;
using System.Collections.Generic;

#nullable disable

namespace Spotify.Models
{
    public partial class User
    {
        public User()
        {
            Playlists = new List<Playlist>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfCreation { get; set; }
        public bool? Privileges { get; set; }

        public virtual List<Playlist> Playlists { get; set; }
    }
}

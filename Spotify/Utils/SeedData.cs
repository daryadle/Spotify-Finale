using Microsoft.EntityFrameworkCore;
using Spotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.Utils
{
    public class SeedData
    {
        public static async Task SeedDatabase(SpotifyContext spoContext)
        {
            List<Artist> artist = new List<Artist>()
            {
                new Artist {ArtistName="Lady Gaga", Albums=new List<Album>(),Songs=new List<Song>()},
                new Artist {ArtistName="Rihanna", Albums=new List<Album>(), Songs=new List<Song>()}
            };
            List<Album> album = new List<Album>()
            {
                new Album{AlbumName="Chromatica", Songs=new List<Song>()},
                new Album{AlbumName="Loud",Songs=new List<Song>()}
            };
            List<Song> song = new List<Song>()
            {
                new Song{Title="Rain On Me"},
                new Song{Title="Question"}
            };

            User user = new User();
            user.UserName = "Darya";
            user.LastName = "Dalaei";
         
        }
    }
}

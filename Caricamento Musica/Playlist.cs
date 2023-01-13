using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaricamentoMusica
{
    public class Playlist
    {
        private List<ItemSong> _songList;
        public string _playlistName;
        public List<ItemSong> SongList { get { return _songList; } set { _songList = value; } }

        public Playlist(string _name)
        {
            _songList = new List<ItemSong>();
            _playlistName = _name;
        }
    }
}

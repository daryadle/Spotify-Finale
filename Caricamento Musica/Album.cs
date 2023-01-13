using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaricamentoMusica
{
    public class Album : Entity
    {
        private List<Song> _songs;
        public List<Song> Songs { get { return _songs; } set { _songs = value; } }
        public Album(string name)
        {
            Name = name;
            _songs = new List<Song>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaricamentoMusica
{
    public class Artist : Entity
    {
        private string _description;
        private List<Album> _albums;
        public List<Album> Albums {get {return _albums;} set { _albums = value; } }
        public Artist(string name)
        {
            Name = name;
            _albums = new List<Album>();
        }
    }
}

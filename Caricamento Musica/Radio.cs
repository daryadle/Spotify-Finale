using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaricamentoMusica
{
    internal class Radio : Entity
    {
        private string _genre;
        public string Genre { get { return _genre; } set { _genre = value; } }

        public Radio(string name, string genre)
        {
            Name = name;
            Genre = genre;
        }

        public Radio()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaricamentoMusica
{
    public class Song : Entity
    {
        private int _listened;

        public int Listened { get { return _listened; } set { _listened = value; } }
        public Song(string name, int listened)
        {
            Name = name;
            Listened = listened;
        }
    }
}

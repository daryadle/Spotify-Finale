using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaricamentoMusica
{
    public class ItemSong
    {
        private string _brano;
        private string _artista;
        private string _album;
        private int _numero_ascolti;
        private string _nome_playlist;
        public string Brano { get { return _brano; } set { _brano = value; } }
        public string Artista { get { return _artista; } set { _artista = value; } }
        public string Album { get { return _album; } set { _album = value; } }
        public int Numero_Ascolti { get { return _numero_ascolti; } set { _numero_ascolti = value; } }
        public string Nome_Playlist { get { return _nome_playlist; } set { _nome_playlist = value; } }
    }
}

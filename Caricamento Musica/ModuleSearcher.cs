using System;
using System.Collections.Generic;
using System.Linq;

namespace CaricamentoMusica
{
    static class ModuleSearcher
    {
        public static Dictionary<string, int> GetTopArtists(List<Artist> artists, int _topnumber)
        {
            Dictionary<string, int> topArtists = new Dictionary<string, int>();

            foreach (var artist in artists)
            {
                (string _artist, int listened) = UserAction.GetListenedFromArtist(artist);

                if (listened > 0)
                    topArtists.Add(_artist, listened);
            }

            topArtists.OrderByDescending(i => i.Value).ToList();

            return topArtists.Take(_topnumber).ToDictionary(item => item.Key, item => item.Value);
        }
    }
}
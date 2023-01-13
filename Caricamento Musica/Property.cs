using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaricamentoMusica
{
    public static class Property
    {
        public static bool SearchAttributes<T>(string[] properties) where T : class, new()
        {
            foreach (var property in properties)
                if (!SearchAttribute<T>(property))
                    return false;
            return true;
        }
        public static bool SearchAttribute<T>(string value) where T : class, new()
        {
            foreach (var property in new T().GetType().GetProperties())
                if (property.Name == value)
                    return true;
            return false;
        }

        public static List<T> SetItems<T>(List<string> _rows) where T : class, new()
        {
            List<T> _media = new List<T>();
            try
            {
                string[] _headers = _rows.ElementAt(0).Replace(' ', '_').Split(',');
                string[] _values;
                _rows.RemoveAt(0);

                T entry = new T();
                int i = 0;
                foreach (var line in _rows)
                {
                    i = 0;
                    entry = new T();
                    foreach (var element in line.Split(','))
                    {
                        try
                        {
                            entry.GetType().GetProperty(_headers[i])
                                .SetValue(entry, Convert.ChangeType(element, entry.GetType().GetProperty(_headers[i]).PropertyType));
                            i++;
                        }
                        catch (System.IndexOutOfRangeException)
                        { return null; }
                        catch (System.NullReferenceException)
                        { return null; }
                    }
                    _media.Add(entry);
                }
            }
            catch (System.ArgumentNullException) { }
            return _media;
        }

        public static List<Artist> SetList(List<ItemSong> _songs)
        {
            List<Artist> _media = new List<Artist>();

            _songs.GroupBy(i => i.Artista).Select(artist => artist.First()).ToList()
                .ForEach(item => _media.Add(new Artist(item.Artista)));

            SetAlbums(_media, _songs);
            SetSongs(_media, _songs);

            return _media;
        }

        private static void SetAlbums(List<Artist> _media, List<ItemSong> _songs)
        {
            foreach (var artist in _media)
                foreach (var song in _songs)
                    if (song.Artista == artist.Name)
                        if (!artist.Albums.Any(i => i.Name == song.Album))
                            artist.Albums.Add(new Album(song.Album));
        }

        private static void SetSongs(List<Artist> _media, List<ItemSong> _songs)
        {
            foreach (var artist in _media)
                foreach (var album in artist.Albums)
                    foreach (var song in _songs)
                        if (song.Artista == artist.Name)
                            if (song.Album == album.Name)
                                if (!album.Songs.Any(i => i.Name == song.Brano))
                                    album.Songs.Add(new Song(song.Brano, song.Numero_Ascolti));
        }


        public static List<Playlist> SetPlaylist(List<ItemSong> _songs)
        {
            List<Playlist> _media = new List<Playlist>();

            _songs.GroupBy(i => i.Nome_Playlist).Select(playlist => playlist.First()).ToList()
                .ForEach(item => _media.Add(new Playlist(item.Nome_Playlist)));

            SetPlaylists(_media, _songs);

            return _media;
        }

        private static void SetPlaylists(List<Playlist> _media, List<ItemSong> _songs)
        {
            foreach (var playlist in _media)
                foreach (var song in _songs)
                    if (song.Nome_Playlist == playlist._playlistName)
                        if (!playlist.SongList.Any(i => i.Brano == song.Brano && i.Artista == song.Artista && i.Album == song.Album))
                            playlist.SongList.Add(song);
        }
    }
}

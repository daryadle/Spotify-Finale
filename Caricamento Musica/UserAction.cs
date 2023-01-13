using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaricamentoMusica
{
    public static class UserAction
    {
        public static void AddSongPlaylistFile(ItemSong _song)
        {
            string[] headers = FileManager.GetHeadersFromFile(FileManager.GetPath(FileManager.LoadFile.Playlist)).Replace(' ', '_').Split(',');
            FileManager.AppendToFile(FileManager.GetPath(FileManager.LoadFile.Playlist), FileManager.SongToFileFormat(_song, headers));
        }

        public static void WritePlaylistsToFile(List<Playlist> _playlists)
        {
            string PathPlaylist = FileManager.GetPath(FileManager.LoadFile.Playlist);
            string[] headers = FileManager.GetHeadersFromFile(PathPlaylist).Replace(' ', '_').Split(',');

            FileManager.ClearFile(PathPlaylist);
            FileManager.AppendToFile(PathPlaylist, FileManager.HeadersToFileFormat(headers));

            foreach (Playlist _playlist in _playlists)
                foreach (ItemSong _song in _playlist.SongList)
                    FileManager.AppendToFile(PathPlaylist, FileManager.SongToFileFormat(_song, headers));
        }

        public static (string, int) GetListenedFromArtist(Artist artist)
        {
            int maxlist = 0;

            foreach (var album in artist.Albums)
                foreach (var song in album.Songs)
                    maxlist += song.Listened;

            return (artist.Name, maxlist);
        }


    }
}

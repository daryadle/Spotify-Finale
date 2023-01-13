using SpotifyWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Caricamento_Musica
{
    public static class DatabaseManager
    {

        static HttpClient client = new HttpClient();
        static void ShowSongs(List<Song> songs)
        {
            foreach (var song in songs)
                Console.WriteLine(song.SongName);
        }
        static async Task<List<Song>> GetAllSongs()
        {
            List<Song> lstSong = null;
            HttpResponseMessage response = await client.GetAsync($"api/Spotify/GetSongs");

            if (response.IsSuccessStatusCode)
                lstSong = await response.Content.ReadAsAsync<List<Song>>();

            return lstSong;
        }
        static async Task<Song> GetIdSongByName(string Name)
        {
            Song song = null;
            HttpResponseMessage response = await client.GetAsync($"api/Spotify/GetIdSongByName/{Name}");

            if (response.IsSuccessStatusCode)
                song = await response.Content.ReadAsAsync<Song>();

            return song;
        }














        static async Task<Song> UpdateListenSongAsync(int id)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"/api/Spotify/UpdateListenSong/{id}", "");
            response.EnsureSuccessStatusCode();

            var song = await response.Content.ReadAsAsync<Song>();
            return song;
        }

        public static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://localhost:5344/");

            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                List<Song> songs = await GetAllSongs();
                //ShowSongs(songs);

                Song fullsong = await GetIdSongByName("Anti-Hero");

                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}

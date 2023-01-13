using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CaricamentoMusica
{
    public static class FileManager
    {
        // Path File Json Settings
        private static string jsonFile = "appsettings.json";
        public static List<string> GetFromFile(string path)
        {
            try
            { return System.IO.File.ReadAllLines(path).ToList(); }
            catch (ArgumentException)
            { return null; }
            catch (System.IO.FileNotFoundException)
            { return null; }
        }

        public static bool AppendToFile(string path, string text)
        {
            try
            { System.IO.File.AppendAllText(path, text); return true; }
            catch (ArgumentException)
            { return false; }
            catch (System.IO.FileNotFoundException)
            { return false; }
        }

        public static bool ClearFile(string path)
        {
            try
            { System.IO.File.WriteAllText(path, string.Empty); return true; }
            catch (ArgumentException)
            { return false; }
            catch (System.IO.FileNotFoundException)
            { return false; }
        }

        public static string GetHeadersFromFile(string path)
        {
            return GetFromFile(path).First();
        }

        public static string GetPath(LoadFile fileChoose)
        {
            switch ((int)fileChoose)
            {
                case 0:
                    return new ConfigurationBuilder().AddJsonFile(jsonFile).Build().GetValue<string>("Configuration:Path:LoadMusic");
                case 1:
                    return new ConfigurationBuilder().AddJsonFile(jsonFile).Build().GetValue<string>("Configuration:Path:LoadPlaylist");
                case 2:
                    return new ConfigurationBuilder().AddJsonFile(jsonFile).Build().GetValue<string>("Configuration:Path:LoadRadio");
            }
            return null;
        }

        public static string SongToFileFormat(ItemSong song, string[] headers)
        {
            string formatSong = "";
            foreach (string header in headers)
                formatSong += song.GetType().GetProperty(header).GetValue(song) + ",";

            return "\n" + formatSong.Remove(formatSong.LastIndexOf(','));
        }

        public static string HeadersToFileFormat(string[] headers)
        {
            string formatSong = "";
            foreach (string header in headers)
                formatSong += header + ",";

            return formatSong.Remove(formatSong.LastIndexOf(',')).Replace('_', ' ');
        }


        public enum LoadFile
        {
            Music,
            Playlist,
            Radio
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Spotify.Models;
using System.Threading.Tasks;
using System;
using System.Linq;
using SpotifyAPI.Web;
using Spotify.Models;
using System.Runtime.CompilerServices;
using System.Web.Http.ModelBinding;



namespace Spotify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpotifyController : ControllerBase
    {
        private readonly ILogger<SpotifyController> logger;
        private readonly IMapper mapper;
        private readonly SpotifyContext context;
        public SpotifyController(ILogger<SpotifyController> _logger, SpotifyContext _context)
        {
            logger = _logger;
            context = _context;
        }
       
        [HttpGet("GetSongs")]
        public async Task<IActionResult> GetSongs()
        {
            try
            {
                var songs = await context.Songs.ToListAsync();

                return Ok(songs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
             
        }
        [HttpGet("GetArtists")]
        public async Task<IActionResult> GetArtists()
        {
            try
            {
                var artists = await context.Artists.ToListAsync();
                return Ok(artists);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAlbums")]
        public async Task<IActionResult> GetAlbums()
        {
            try
            {
                var albums = await context.Albums.ToListAsync();
                return Ok(albums);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetPlaylists")]
        public async Task<IActionResult> GetPlaylists()
        {
            try
            {
                var playlists = await context.Playlists.ToListAsync();
                return Ok(playlists);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetListSongPlaylist")]
        public async Task<IActionResult> GetListSongPlaylist()
        {
            try
            {
                var listSongPlaylist = await context.ListSongPlaylists.ToListAsync();
                return Ok(listSongPlaylist);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await context.Users.ToListAsync();
                return Ok(users);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddSongs")]
        public async Task<IActionResult> Create([Bind("Title,Genre")] Song song)
        {
            if (ModelState.IsValid)
            {
                context.Add(song);
                await context.SaveChangesAsync();
                return RedirectToAction("index");
            }
            return View(song);
        }
        private IActionResult View(Song song)
        {
            throw new NotImplementedException();
        }


        [HttpPost("AddArtists")]
        public async Task<IActionResult> Create([Bind("ArtistName,ArtistId")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                context.Add(artist);
                await context.SaveChangesAsync();
                return RedirectToAction("index");
            }
            return View(artist);
        }
        private IActionResult View(Artist artist)
        {
            throw new NotImplementedException();
        }


        [HttpPost("AddAlbums")]
        public async Task<IActionResult> Create([Bind("AlbumName")] Album album)
        {
            if (ModelState.IsValid)
            {
                context.Add(album);
                await context.SaveChangesAsync();
                return RedirectToAction("index");
            }
            return View(album);
        }
        private IActionResult View(Album album)
        {
            throw new NotImplementedException();
        }

        [HttpPost("AddPlaylists")]
        public async Task<IActionResult> Create([Bind("Title")] Playlist playList)
        {
            if (ModelState.IsValid)
            {
                context.Add(playList);
                await context.SaveChangesAsync();
                return RedirectToAction("index");
            }
            return View(playList);
        }
        private IActionResult View(Playlist playList)
        {
            throw new NotImplementedException();
        }

        [HttpPost("AddUsers")]
        public async Task<IActionResult> Create([Bind("FirstName,LastName")] User user)
        {
            if (ModelState.IsValid)
            {
                context.Add(user);
                await context.SaveChangesAsync();
                return RedirectToAction("index");
            }
            return View(user);
        }
        private IActionResult View(User user)
        {
            throw new NotImplementedException();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Modul10_103022400046.Models;

namespace Modul10_103022400046.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private static List<Game> gameList = new List<Game>
        {
            new Game { Nama = "Valorant", Developer = "Riot Games", TahunRilis = 2020, Genre = "FPS", Rating = 8.5, Platform = ["PC"], Mode = ["Multiplayer"], IsOnline = true, Harga = 0 },
            new Game { Nama = "GTA V", Developer = "Rockstar Games", TahunRilis = 2013, Genre = "Open World", Rating = 9.5, Platform = ["PC", "PS5", "PS4", "Xbox"], 
                Mode = ["SinglePlayer", "MultiPlayer"], IsOnline = true, Harga = 300000 },
            new Game { Nama = "GTA V", Developer = "Rockstar Games", TahunRilis = 2015, Genre = "RPG", Rating = 9.7, Platform = ["PC", "PS5", "PS4", "Xbox", "Switch"],
                Mode = ["SinglePlayer"], IsOnline = false, Harga = 250000 },
        };

        [HttpGet]
        public IEnumerable<Game> Get()
        {
            return gameList;
        }

        [HttpGet("{id}")]
        public ActionResult<Game> Get(int id)
        {
            if (id < 0 || id >= gameList.Count)
            {
                return NotFound("Index film tidak ditemukan.");
            }
            return gameList[id];
        }

        [HttpPost]
        public IActionResult Post([FromBody] Game newGame)
        {
            gameList.Add(newGame);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= gameList.Count)
            {
                return NotFound("Index film tidak ditemukan.");
            }
            gameList.RemoveAt(id);
            return Ok();
        }

        //[HttpPut("{id}")]
        //public ActionResult<Game> Update(int id, Game gameUpdate)
        //{
        //    var index = gameList.FindIndex(g => g.id == id);
        //    if (index == -1)
        //    {
        //        return NotFound("gagal");

        //        gameList[index] = gameUpdate;
        //    }
        //}

    }
}

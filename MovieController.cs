using Microsoft.AspNetCore.Mvc;
using modul10_103022300005.Models;
using System.Collections;
using System.Collections.Generic;
namespace modul10_103022300005.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private static List<string> stars1 = new List<string>
        {
            new string ("Tim Robbins"), 
            new string ("MorgaN Freeman"),
            new string ("Bob Gunton")
        };

        private static List<string> stars2 = new List<string>
        {
            new string ("Marlon Brando"),
            new string ("Al Pacino"),
            new string ("James Caan")
        };

        private static List<string> stars3 = new List<string>
        {
            new string ("Christian Bale"),
            new string ("Heath Ledger"),
            new string ("Aaron Eckhart")
        };

        private static List<Movie> movieList = new List<Movie>
        {
            new Movie ( "The Shawshank Redemption", "Frank Darabont", stars1, "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion."),
            new Movie ( "The Godfather", "Francis Ford Coppola", stars2, "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."),
            new Movie ("The Dark Knight", "Christopher Nolan", stars3, "When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness.")
        };

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetAll()
        {
            return Ok(movieList);
        }

        [HttpGet("{index}")]
        public ActionResult<Movie> GetByIndex(int index)
        {
            if (index < 0 || index >= movieList.Count)
                return NotFound("Index tidak ditemukan.");

            return Ok(movieList[index]);
        }

        [HttpPost]
        public ActionResult AddMovie([FromBody] Movie newMovie)
        {
            movieList.Add(newMovie);
            return Ok("Movie berhasil ditambahkan.");
        }

        [HttpDelete("{index}")]
        public ActionResult DeleteMovie(int index)
        {
            if (index < 0 || index >= movieList.Count)
                return NotFound("Index tidak ditemukan.");

            movieList.RemoveAt(index);
            return Ok("Movie berhasil dihapus.");
        }
    }
}


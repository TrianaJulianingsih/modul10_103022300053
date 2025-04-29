using Microsoft.AspNetCore.Mvc;
using modul10_103022300053.Models;
using System.Collections.Generic;
namespace modul10_103022300053.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private static List<Movie> Movies = new List<Movie>
        {
            new Movie("The Showshank Redemption", "Frank Darabont", ["Tim Robbins", "Morgan Freeman", "Bob Gunton", "William Sadler"], "Two imprisoned men bond over a number of years, finding soloce and eventual redemption through acts of common decency."),
            new Movie("The Godfather", "Francis Ford Coppola", ["Morlan Brando", "Al Pacino", "James Caan", "Diane Keaton"], "The aging patriarch of an organized crime dynasty in postwar New York City transfers control of his clandestine empire to this reluctant youngest son."),
            new Movie("The Dark Knight", "Christopher Nolan", ["Christian Bale", "Heath Ledger", "Aaron Eckhart", "Michael Caine"], "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the grea test psychological and physical tests of his ability to fight injustice.")
        };

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetAll()
        {
            return Ok(Movies);
        }
        [HttpGet("{index}")]
        public ActionResult<Movie> GetByIndex(int index)
        {
            if (index < 0 || index >= Movies.Count)
                return NotFound("Index tidak ditemukan.");

            return Ok(Movies[index]);
        }
        [HttpPost]
        public ActionResult AddMahasiswa([FromBody] Movie newMahasiswa)
        {
            Movies.Add(newMahasiswa);
            return Ok("Mahasiswa berhasil ditambahkan.");
        }

        [HttpDelete("{index}")]
        public ActionResult DeleteMahasiswa(int index)
        {
            if (index < 0 || index >= Movies.Count)
                return NotFound("Index tidak ditemukan.");

            Movies.RemoveAt(index);
            return Ok("Mahasiswa berhasil dihapus.");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MoviesAPI.Models;
  
namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {

        private static List<Movie> movies = new List<Movie>();
        private static int id = 0;

        [HttpPost]
        public void AddMovie([FromBody] Movie movie)
        {
            movie.Id = id++;
            movies.Add(movie);
        }

        [HttpGet]
        public IEnumerable<Movie> GetMovie()
        {
            return movies;
        }

        [HttpGet("{id")]
        public Movie? GetMovieById(int id) 
        {
            return movies.FirstOrDefault(movie => movie.Id == id);
        }
    }
}

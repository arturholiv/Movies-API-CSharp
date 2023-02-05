using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private MovieContext _context;
        private IMapper _mapper;

        public MovieController(MovieContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
        {
            Movie movie = _mapper.Map<Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMovieById), new {id = movie.Id}, movie); 
        }

        [HttpGet]
        public IEnumerable<Movie> GetMovie([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _context.Movies.Skip(skip).Take(take);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id) 
        {
            var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }

        [HttpPut]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDto movieDto) 
        {
            var movie = _context.Movies.FirstOrDefault(movie =>movie.Id == id);
            if (movie == null) return NotFound();
            _mapper.Map(movieDto, movie);
            return NoContent();
        }
    }
}

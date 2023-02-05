using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos
{
    public class ReadMovieDto
    {
        public string Title { get; set; }

        public string Gender { get; set; }

        public int Duration { get; set; }

        public DateTime ConsultTime { get; set; } = DateTime.Now;
    }
}

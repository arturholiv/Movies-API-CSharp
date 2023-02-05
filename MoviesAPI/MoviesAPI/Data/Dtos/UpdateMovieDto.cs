using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos
{
    public class UpdateMovieDto
    {
        [Required(ErrorMessage = "The Movie title is required")]
        [StringLength(120)]
        public string Title { get; set; }

        [Required(ErrorMessage = "The Movie gender is required")]
        [StringLength(50, ErrorMessage = "The Movie gender can not be higher than 50")]
        public string Gender { get; set; }

        [Required]
        [Range(70, 600, ErrorMessage = "The Movie duration must be between 60 and 600 minutes")]
        public int Duration { get; set; }
    }
}

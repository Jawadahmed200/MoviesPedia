using MoviesPediaDataAccessLibrary.Entities;
using System.ComponentModel.DataAnnotations;

namespace MoviePedia.DTOs
{
    public class MovieCreationDTO
    {
        [Required]
        [StringLength(maximumLength:150)]
        public string Title { get; set; } = null!;
        public bool InTheaters { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<int> Genres { get; set; } = new List<int>();
        public List<MovieActorCreationDTO> MoviesActors { get; set; } = new List<MovieActorCreationDTO>();
    }

    public class MovieActorCreationDTO
    {
        public int ActorId { get; set; }
        public string Character { get; set; } = null!;
    }
}

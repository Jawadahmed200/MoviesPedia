using System.ComponentModel.DataAnnotations;

namespace MoviePedia.DTOs
{
    public class GenreCreationDTO
    {
        [Required]
        [StringLength(maximumLength:150)]
        public string Name { get; set; } = null!;
    }
}

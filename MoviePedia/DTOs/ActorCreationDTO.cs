using System.ComponentModel.DataAnnotations;

namespace MoviePedia.DTOs
{
    public class ActorCreationDTO
    {
        [Required]
        [StringLength(maximumLength:150)]
        public string Name { get; set; }
        public decimal Fortune { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}

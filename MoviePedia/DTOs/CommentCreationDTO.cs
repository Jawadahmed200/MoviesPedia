using MoviesPediaDataAccessLibrary.Entities;

namespace MoviePedia.DTOs
{
    public class CommentCreationDTO
    {
        public string? Content { get; set; } = null!;
        public bool Recommend { get; set; }
    }
}

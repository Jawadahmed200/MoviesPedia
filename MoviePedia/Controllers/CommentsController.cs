using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviePedia.DTOs;
using MoviesPediaDataAccessLibrary.Data;
using MoviesPediaDataAccessLibrary.Entities;

namespace MoviePedia.Controllers
{
    [ApiController]
    [Route("api/movies/{movieId:int}/comments")]
    public class CommentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CommentsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult> Post(int movieId, CommentCreationDTO commentCreationDTO)
        {
            var comment = _mapper.Map<Comment>(commentCreationDTO);
            comment.MovieId = movieId;
            
            _context.Add(comment);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

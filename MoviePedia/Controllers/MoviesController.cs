using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviePedia.DTOs;
using MoviesPediaDataAccessLibrary.Data;
using MoviesPediaDataAccessLibrary.Entities;

namespace MoviePedia.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController:ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MoviesController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Movie>> Get(int id)
        {
            var movie = await _context.Movies.Include(x=>x.Comments)
                                .Include(x=>x.Genres)
                                .Include(x=>x.MoviesActors)
                                    .ThenInclude(x=>x.Actor)
                                .FirstOrDefaultAsync(x => x.Id == id);
            if (movie is null)
            {
                return NotFound();
            }
            return movie;

        }

        [HttpGet("select/{id:int}")]
        public async Task<ActionResult> GetSelect(int id)
        {
            var movie = await _context.Movies.Include(x => x.Comments)
                                .Select(mov=>new
                                {
                                    Id=mov.Id,
                                    Title=mov.Title,
                                    Genres=mov.Genres.Select(g=>g.Name).ToList(),
                                    Actors = mov.MoviesActors.OrderBy(x => x.Order).Select(m=>new
                                    {
                                        Id=m.ActorId,
                                        Name=m.Actor.Name,
                                        Characters=m.Character
                                    }),
                                    CommentsQty=mov.Comments.Count()
                                })
                                .FirstOrDefaultAsync(x => x.Id == id);
            if (movie is null)
            {
                return NotFound();
            }
            return Ok(movie);

        }


        [HttpPost]
        public async Task<ActionResult> Post(MovieCreationDTO movieCreationDTO)
        {
            var movie = _mapper.Map<Movie>(movieCreationDTO);

            if(movie.Genres is not null)
            {
                foreach (var genre in movie.Genres)
                {
                    _context.Entry(genre).State = EntityState.Unchanged;
                }
            }
            if(movie.MoviesActors is not null)
            {
                for (int i = 0; i < movie.MoviesActors.Count; i++)
                {
                    movie.MoviesActors[i].Order = i + 1;
                }
            }

            _context.Add(movie);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

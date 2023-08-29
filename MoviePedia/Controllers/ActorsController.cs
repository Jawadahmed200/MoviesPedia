using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviePedia.DTOs;
using MoviesPediaDataAccessLibrary.Data;
using MoviesPediaDataAccessLibrary.Entities;

namespace MoviePedia.Controllers
{
    [ApiController]
    [Route("api/actors")]
    public class ActorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ActorsController(ApplicationDbContext applicationDbContext1, IMapper mapper)
        {
            _context = applicationDbContext1;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> Get()
        {
            return await _context.Actors.ToListAsync();
        }


        [HttpGet("dateOfBirth/range")]
        public async Task<ActionResult<IEnumerable<Actor>>> GetDOB(DateTime start, DateTime end)
        {
            return await _context.Actors.Where(x => x.DateOfBirth >= start && x.DateOfBirth <= end).ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Actor>> Get(int id)
        {
            var actor = await _context.Actors.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (actor is null)
            {
                return NotFound();
            }
            return actor;

        }

        [HttpPost]
        public async Task<ActionResult> Post(ActorCreationDTO actorCreationDTO)
        {
            var actor = _mapper.Map<Actor>(actorCreationDTO);
            _context.Add(actor);
            await _context.SaveChangesAsync();
            return Ok();
        }


    }
}

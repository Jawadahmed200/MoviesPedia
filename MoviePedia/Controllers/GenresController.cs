using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviePedia.DTOs;
using MoviesPediaDataAccessLibrary.Data;
using MoviesPediaDataAccessLibrary.Entities;

namespace MoviePedia.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenresController:ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GenresController(ApplicationDbContext context, IMapper mapper)
        {
           _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> Get()
        {
            return await  _context.Genres.ToListAsync();
        }

        [HttpPut("{id:int}/name2")]
        public async Task<ActionResult> Put(int id)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(x=>x.Id==id);
            if(genre is null)
            {
                return NotFound();
            }
            genre.Name = genre.Name + " Updated";
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, GenreCreationDTO genreCreationDTO)
        {
            var genre= _mapper.Map<Genre>(genreCreationDTO);

            genre.Id = id;
            _context.Update(genre);
           
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}/moderndelete")]
        public async Task<ActionResult> Delete(int id)
        {
            var removedRows = await _context.Genres.Where(x => x.Id == id).ExecuteDeleteAsync();
            if(removedRows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Post(GenreCreationDTO genreCreationDTO)
        {
            var isGenreAlreadyExists = await _context.Genres.AnyAsync(c => c.Name == genreCreationDTO.Name);
            if (isGenreAlreadyExists)
            {
                return BadRequest("There is already genre with name: " + genreCreationDTO.Name);
            }

            var genre = _mapper.Map<Genre>(genreCreationDTO);
            _context.Add(genre);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("multiple")]
        public async Task<ActionResult> Post(GenreCreationDTO[] genreCreationDTO)
        {
            var genres = _mapper.Map<Genre[]>(genreCreationDTO);
            _context.AddRange(genres);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}

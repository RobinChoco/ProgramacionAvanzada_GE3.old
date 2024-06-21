using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControlBiblioteca.Models;
using ControlBiblioteca.DTOs;
using AutoMapper;
using ControlBiblioteca.Data;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ControlBiblioteca.Controllers
{
    [ApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly BIBLIOTECAContext _context;
        private readonly IMapper _mapper;

        public LibrosController(BIBLIOTECAContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibroDto>>> GetLibros()
        {
            var libros = await _context.Libros.ToListAsync();

            var libroDtos = _mapper.Map<List<LibroDto>>(libros);
            return libroDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LibroDto>> GetLibro(int id)
        {
            var libro = await _context.Libros.FindAsync(id);

            if (libro == null)
            {
                return NotFound();
            }

            var libroDto = _mapper.Map<LibroDto>(libro);
            return libroDto;
        }

        [HttpPut]
        public async Task<IActionResult> PutLibro(LibroDto libroDto)
        {
            var libro = _mapper.Map<Libro>(libroDto);
            _context.Libros.Update(libro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibro", new { id = libro.LibroId }, _mapper.Map<LibroDto>(libro));
        }

        [HttpPost]
        public async Task<ActionResult<LibroDto>> PostLibro(LibroDto libroDto)
        {
            var libro = _mapper.Map<Libro>(libroDto);
            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibro", new { id = libro.LibroId }, _mapper.Map<LibroDto>(libro));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibro(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }

            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

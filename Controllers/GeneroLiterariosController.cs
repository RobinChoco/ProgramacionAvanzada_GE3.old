using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControlBiblioteca.Data;
using ControlBiblioteca.Models;
using AutoMapper;
using ControlBiblioteca.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ControlBiblioteca.Controllers
{
    [ApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroLiterariosController : ControllerBase
    {
        private readonly BIBLIOTECAContext _context;
        private readonly IMapper _mapper;

        public GeneroLiterariosController(BIBLIOTECAContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/GeneroLiterarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneroLiterarioDto>>> GetGeneroLiterarios()
        {
            var genrosLiterarios = await _context.GeneroLiterarios.ToListAsync();

            var genLitDtos = _mapper.Map<List<GeneroLiterarioDto>>(genrosLiterarios);
            return genLitDtos;
        }

        // GET: api/GeneroLiterarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeneroLiterarioDto>> GetGeneroLiterario(int id)
        {
            var generoLiterario = await _context.GeneroLiterarios.FindAsync(id);

            if (generoLiterario == null)
            {
                return NotFound();
            }

            var generoLiterarioDto = _mapper.Map<GeneroLiterarioDto>(generoLiterario);
            return generoLiterarioDto;
        }


        // PUT: api/GeneroLiterarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutGeneroLiterario(GeneroLiterarioDto generoLiterarioDto)
        {
            // Método para actualizar un autor
            // Responde a las solicitudes PUT en la ruta con el ID del autor ("/api/Autor/5")
            var generoLiterario = _mapper.Map<GeneroLiterario>(generoLiterarioDto);
            _context.GeneroLiterarios.Update(generoLiterario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeneroLiterario", new { id = generoLiterario.GeneroLiterarioId }, _mapper.Map<GeneroLiterarioDto>(generoLiterario));
        }

        /// <param name="generoLiterarioDto">Datos del nuevo autor.</param>

        // POST: api/GeneroLiterarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GeneroLiterarioDto>> PostGeneroLiterario(GeneroLiterarioDto generoLiterarioDto)
        {
            var generoLiterario = _mapper.Map<GeneroLiterario>(generoLiterarioDto);
            _context.GeneroLiterarios.Add(generoLiterario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeneroLiterario", new { id = generoLiterario.GeneroLiterarioId }, _mapper.Map<GeneroLiterarioDto>(generoLiterario));
        }

        // DELETE: api/GeneroLiterarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeneroLiterario(int id)
        {
            var generoLiterario = await _context.GeneroLiterarios.FindAsync(id);
            if (generoLiterario == null)
            {
                return NotFound();
            }

            _context.GeneroLiterarios.Remove(generoLiterario);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}

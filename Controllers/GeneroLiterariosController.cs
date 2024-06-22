using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControlBiblioteca.Data;
using ControlBiblioteca.Models;
using AutoMapper;
using ControlBiblioteca.DTOs;
using ControlBiblioteca.Interfaces;

namespace ControlBiblioteca.Controllers
{
    [TypeFilter(typeof(ApiKeyAttribute))]
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroLiterariosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GeneroLiterariosController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/GeneroLiterarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneroLiterarioDto>>> GetGeneroLiterarios()
        {
            // Antes: var genrosLiterarios = await _context.GeneroLiterarios.ToListAsync();
            var generosLiterarios = await _unitOfWork.GeneroLiterario.GetGeneroLiterariosAsync();

            var generosLiterariosDto = _mapper.Map<List<GeneroLiterarioDto>>(generosLiterarios);
            return generosLiterariosDto;
        }

        // GET: api/GeneroLiterarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeneroLiterarioDto>> GetGeneroLiterario(int id)
        {
            // Antes: var generoLiterario = await _context.GeneroLiterarios.FindAsync(id);
            var generoLiterario = await _unitOfWork.GeneroLiterario.FindByIdAsync(id);

            if (generoLiterario == null)
            {
                return NotFound();
            }

            var generoLiterarioDto = _mapper.Map<GeneroLiterarioDto>(generoLiterario);
            return generoLiterarioDto;
        }

        // PUT: api/GeneroLiterarios
        [HttpPut]
        public async Task<IActionResult> PutGeneroLiterario(GeneroLiterarioDto generoLiterarioDto)
        {
            // Antes: var generoLiterario = _mapper.Map<GeneroLiterario>(generoLiterarioDto);
            // Antes: _context.GeneroLiterarios.Update(generoLiterario);
            // Antes: await _context.SaveChangesAsync();

            var generoLiterario = _mapper.Map<GeneroLiterario>(generoLiterarioDto);
            _unitOfWork.GeneroLiterario.Update(generoLiterario);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetGeneroLiterario", new { id = generoLiterario.GeneroLiterarioID }, _mapper.Map<GeneroLiterarioDto>(generoLiterario));
        }

        // POST: api/GeneroLiterarios
        [HttpPost]
        public async Task<ActionResult<GeneroLiterarioDto>> PostGeneroLiterario(GeneroLiterarioDto generoLiterarioDto)
        {
            // Antes: var generoLiterario = _mapper.Map<GeneroLiterario>(generoLiterarioDto);
            // Antes: _context.GeneroLiterarios.Add(generoLiterario);
            // Antes: await _context.SaveChangesAsync();

            var generoLiterario = _mapper.Map<GeneroLiterario>(generoLiterarioDto);
            _unitOfWork.GeneroLiterario.Create(generoLiterario);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetGeneroLiterario", new { id = generoLiterario.GeneroLiterarioID }, _mapper.Map<GeneroLiterarioDto>(generoLiterario));
        }

        // DELETE: api/GeneroLiterarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeneroLiterario(int id)
        {
            // Antes: var generoLiterario = await _context.GeneroLiterarios.FindAsync(id);
            var generoLiterario = await _unitOfWork.GeneroLiterario.FindByIdAsync(id);
            if (generoLiterario == null)
            {
                return NotFound();
            }

            _unitOfWork.GeneroLiterario.Delete(generoLiterario);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }
    }
}

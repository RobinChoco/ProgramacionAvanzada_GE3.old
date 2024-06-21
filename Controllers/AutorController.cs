using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlBiblioteca.Data;
using ControlBiblioteca.Models;
using AutoMapper;
using ControlBiblioteca.DTOs;
using ControlBiblioteca.Middleware;
using ControlBiblioteca.Interfaces;

namespace ControlBiblioteca.Controllers
{
    [ApiKey]

    // Especifica que este controlador responde a las solicitudes en la ruta "/api/[controller]"
    // donde "[controller]" se sustituye por el nombre de la clase sin "Controller" al final
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly BIBLIOTECAContext _context;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        // Constructor del controlador que recibe un contexto de base de datos y un objeto IMapper de AutoMapper
        public AutorController(BIBLIOTECAContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            //_unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Obtiene todos los autores.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutorDto>>> GetAutores()
        {
            // Método para obtener todos los autores
            // Responde a las solicitudes GET en la ruta base del controlador ("/api/Autor")
            var autores = await _context.Autors.ToListAsync();

            var autorDtos = _mapper.Map<List<AutorDto>>(autores);
            return autorDtos;
        }

        /// <summary>
        /// Obtiene un autor por su ID.
        /// </summary>
        /// <param name="id">ID del autor.</param>
        [HttpGet("{id}")]
        public async Task<ActionResult<AutorDto>> GetAutor(int id)
        {
            // Método para obtener un autor por su ID
            // Responde a las solicitudes GET en la ruta con el ID del autor ("/api/Autor/5")

            var autor = await _context.Autors.FindAsync(id);

            if (autor == null)
            {
                return NotFound();
            }

            var autorDto = _mapper.Map<AutorDto>(autor);
            return autorDto;
        }

        /// <summary>
        /// Actualiza un autor existente.
        /// </summary>
        /// <param name="autorDto">Datos del autor actualizados.</param>
        [HttpPut]
        public async Task<IActionResult> PutAutor(AutorDto autorDto)
        {
            // Método para actualizar un autor
            // Responde a las solicitudes PUT en la ruta con el ID del autor ("/api/Autor/5")
            var autor = _mapper.Map<Autor>(autorDto);
            _context.Autors.Update(autor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutor", new { id = autor.AutorId }, _mapper.Map<AutorDto>(autor));
        }

        /// <summary>
        /// Crea un nuevo autor.
        /// </summary>
        /// <param name="autorDto">Datos del nuevo autor.</param>
        [HttpPost]
        public async Task<ActionResult<AutorDto>> PostAutor(AutorDto autorDto)
        {
            // Método para crear un nuevo autor
            // Responde a las solicitudes POST en la ruta base del controlador ("/api/Autor")

            var autor = _mapper.Map<Autor>(autorDto);
            _context.Autors.Add(autor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutor", new { id = autor.AutorId }, _mapper.Map<AutorDto>(autor));
        }


        /// <summary>
        /// Elimina un autor por su ID.
        /// </summary>
        /// <param name="id">ID del autor a eliminar.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutor(int id)
        {
            // Método para eliminar un autor por su ID
            // Responde a las solicitudes DELETE en la ruta con el ID del autor ("/api/Autor/5")

            var autor = await _context.Autors.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }

            _context.Autors.Remove(autor);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
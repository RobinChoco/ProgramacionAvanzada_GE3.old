﻿using ControlBiblioteca.Data;
using ControlBiblioteca.Interfaces;
using ControlBiblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlBiblioteca.Repositories
{
    public class GeneroLiterarioRepository : BaseRepository<GeneroLiterario>, IGeneroLiterarioRepository
    {
        public GeneroLiterarioRepository(BIBLIOTECAContext context) : base(context) 
        { 
        
        }
        public async Task<List<GeneroLiterario>> GetGeneroLiterarioAsync()
        {
            return await Context.GeneroLiterarios.ToListAsync();
        }

        public async Task<GeneroLiterario?> GetGeneroLiterarioById(int generoLiterarioId) //Con el signo ? hacemos referencia a posible envío de null
        {
            return await Context.GeneroLiterarios.FirstOrDefaultAsync(x => x.GeneroLiterarioID == generoLiterarioId);
        }


     }
}

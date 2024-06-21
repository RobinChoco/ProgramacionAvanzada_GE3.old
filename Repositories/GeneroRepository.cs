using ControlBiblioteca.Data;
using ControlBiblioteca.Interfaces;
using ControlBiblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlBiblioteca.Repositories
{
    public class GeneroRepository : BaseRepository<Autor>, IGeneroRepository
    {
        public GeneroRepository(BIBLIOTECAContext context) : base(context)
        {

        }

        public async Task<List<GeneroLiterario>> GetGeneroLiterarioAsync()
        {
            return await Context.GeneroLiterarios.ToListAsync();
        }

        public async Task<GeneroLiterario?> GetGeneroLiterarioById(int GeneroLiterarioId)
        {
            return await Context.GeneroLiterarios.FirstOrDefaultAsync(x => x.GeneroLiterarioID == GeneroLiterarioId);
        }
    }
}

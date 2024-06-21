using ControlBiblioteca.Data;
using ControlBiblioteca.Interfaces;
using ControlBiblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlBiblioteca.Repositories
{
    public class LibroRepository : BaseRepository<Libro>, ILibroRepository
    {
        public LibroRepository(BIBLIOTECAContext context) : base(context) 
        {
        
        }

        public async Task<List<Libro>> GetLibroAsync()
        {
            return await Context.Libros.ToListAsync();
        }

        public async Task<Libro?> GetLibroById(int libroId)
        {
            return await Context.Libros.FirstOrDefaultAsync(x => x.LibroId == libroId);
        }
    }
}

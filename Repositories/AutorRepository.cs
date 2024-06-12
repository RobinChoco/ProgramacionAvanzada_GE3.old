using ControlBiblioteca.Data;
using ControlBiblioteca.Interfaces;
using ControlBiblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlBiblioteca.Repositories
{
    public class AutorRepository : BaseRepository<Autor>, IAutorRepository
    {
        public AutorRepository(BIBLIOTECAContext context) : base(context)
        {

        }

        public async Task<List<Autor>> GetAutorAsync()
        {
            return await Context.Autors.ToListAsync();
        }

        public async Task<Autor?> GetAutorById(int autorId)
        {
            return await Context.Autors.FirstOrDefaultAsync(x => x.AutorId == autorId);
        }
    }
}

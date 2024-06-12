using ControlBiblioteca.Data;
using ControlBiblioteca.Interfaces;
using ControlBiblioteca.Models;
using ControlBiblioteca.Repositories;

namespace ControlBiblioteca.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BIBLIOTECAContext _context;

        private IAutorRepository _autor = default!;
        private IParametroRepository _parametro = default!;

        public IAutorRepository Autor => _autor ?? new AutorRepository(_context);
        public IParametroRepository Parametro => _parametro ?? new ParametroRepository(_context);

        public UnitOfWork(BIBLIOTECAContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

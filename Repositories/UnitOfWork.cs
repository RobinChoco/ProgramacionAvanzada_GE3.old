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
        private IGeneroLiterarioRepository _generoLiterario = default!;   
        private ILibroRepository _libro = default!; 

        public IAutorRepository Autor => _autor ?? new AutorRepository(_context);
        public IParametroRepository Parametro => _parametro ?? new ParametroRepository(_context);

        public IGeneroLiterarioRepository GeneroLiterario => _generoLiterario ?? new GeneroRepository(_context);

        public ILibroRepository Libro => _libro ?? new LibroRepository(_context);

        public UnitOfWork(BIBLIOTECAContext context)
        {
            _context = context;
            _autor = new AutorRepository(_context); // Inicialización opcional si se desea
            _parametro = new ParametroRepository(_context); // Inicialización opcional si se desea
            _generoLiterario = new GeneroRepository(_context); // Inicialización opcional si se desea
            _libro = new LibroRepository(_context); // Inicialización opcional si se desea
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

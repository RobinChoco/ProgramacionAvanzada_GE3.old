using ControlBiblioteca.Data;
using ControlBiblioteca.DTOs;
using ControlBiblioteca.Interfaces;
using ControlBiblioteca.Models;
using Microsoft.Data.SqlClient;
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
        public async Task<StoredProcedureDto?> CreateNewLibro(LibroDto resource)
        {
            var paramLibroId = new SqlParameter("@LibroId", resource.LibroId);
            var paramGeneroLiterarioId = new SqlParameter("@GeneroLiterarioId", resource.GeneroLiterarioId);
            var paramAutorId = new SqlParameter("@AutorId", resource.AutorId);
            var paramNombreLibro = new SqlParameter("@NombreLibro", resource.NombreLibro);
            var paramEstado = new SqlParameter("@Estado", resource.Estado);
            var paramFechaCreacion = new SqlParameter("@FechaCreacion", resource.FechaCreacion ?? DateTime.Now);

            var responseSp = await Context.Set<StoredProcedureDto>().FromSqlRaw("EXECUTE [dbo].[spNewLibro] @LibroId, @GeneroLiterarioId, @AutorId, @NombreLibro, @Estado, @FechaCreacion",
                paramLibroId, paramGeneroLiterarioId, paramAutorId, paramNombreLibro, paramEstado, paramFechaCreacion).ToListAsync();

            return responseSp.FirstOrDefault();
        }

    }
}
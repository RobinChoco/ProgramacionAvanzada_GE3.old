using ControlBiblioteca.Data;
using ControlBiblioteca.DTOs;
using ControlBiblioteca.Interfaces;
using ControlBiblioteca.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ControlBiblioteca.Repositories
{
    public class GeneroRepository : BaseRepository<GeneroLiterario>, IGeneroLiterarioRepository
    {
        public GeneroRepository(BIBLIOTECAContext context) : base(context)
        {
        }
        public async Task<List<GeneroLiterario>> GetGeneroLiterariosAsync()
        {
            return await Context.GeneroLiterarios.ToListAsync();
        }

        public async Task<GeneroLiterario?> GetGeneroLiterarioById(int GeneroLiterarioId) //Con el signo ? hacemos referencia a posible envío de null
        {
            return await Context.GeneroLiterarios.FirstOrDefaultAsync(x => x.GeneroLiterarioID == GeneroLiterarioId);
        }

        public async Task<StoredProcedureDto?> CreateNewGenero(GeneroLiterarioDto resource)
        {
            var paramGeneroLiterarioId = new SqlParameter("@GeneroLiterarioId", resource.GeneroLiterarioID);
            var paramDescripcion = new SqlParameter("@Descripcion", resource.Descripcion);
            var paramEstado = new SqlParameter("@Estado", resource.Estado);
            var paramFechaCreacion = new SqlParameter("@FechaCreacion", resource.FechaCreacion ?? DateTime.Now);

            var responseSp = await Context.Set<StoredProcedureDto>().FromSqlRaw("EXECUTE [dbo].[spNewGenero] @GeneroLiterarioId, @Descripcion, @Estado, @FechaCreacion",
                paramGeneroLiterarioId, paramDescripcion, paramEstado, paramFechaCreacion).ToListAsync();

            return responseSp.FirstOrDefault();
        }


    }
}

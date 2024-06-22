using ControlBiblioteca.Models;
using ControlBiblioteca.DTOs;


namespace ControlBiblioteca.Interfaces
{
    public interface IGeneroLiterarioRepository : IBaseRepository<GeneroLiterario>
    {
        Task<List<GeneroLiterario>> GetGeneroLiterariosAsync();
        Task<GeneroLiterario?> GetGeneroLiterarioById(int generoLiterarioId);
        Task<StoredProcedureDto?> CreateNewGenero(GeneroLiterarioDto resource);
    }
}
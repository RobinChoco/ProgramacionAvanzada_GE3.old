using ControlBiblioteca.Models;

namespace ControlBiblioteca.Interfaces
{
    public interface IGeneroLiterarioRepository : IBaseRepository<GeneroLiterario>
    {
        Task<List<GeneroLiterario>> GetGeneroLiterarioAsync();
        Task<GeneroLiterario?> GetGeneroLiterarioById(int generoLiterarioId);// ? significa posibilidad de null
    }
}

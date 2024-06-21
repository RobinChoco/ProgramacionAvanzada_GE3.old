
using ControlBiblioteca.DTOs;
using ControlBiblioteca.Models;
 
namespace ControlBiblioteca.Interfaces
{
    public interface IGeneroRepository
    {
        Task<List<GeneroLiterario>> GetGeneroLiterarioAsync();
        Task<GeneroLiterario?> GetGeneroLiterarioById(int autorId);
        //Task<StoredProcedureDto?> CreateNewGeneroLiterario(GeneroLiterarioDto resource);
    }
}
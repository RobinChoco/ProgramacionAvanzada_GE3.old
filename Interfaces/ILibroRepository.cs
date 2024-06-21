
using ControlBiblioteca.DTOs;
using ControlBiblioteca.Models;
 
namespace ControlBiblioteca.Interfaces
{
    public interface ILibroRepository
    {
        Task<List<Libro>> GetLibroAsync();
        Task<Libro?> GetLibroById(int autorId);
       // Task<StoredProcedureDto?> CreateNewLibro(LibroDto resource);
    }
}
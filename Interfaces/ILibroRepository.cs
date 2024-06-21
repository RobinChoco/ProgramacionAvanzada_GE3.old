﻿using ControlBiblioteca.Models;

namespace ControlBiblioteca.Interfaces
{
    public interface ILibroRepository : IBaseRepository<Libro>
    {
        Task<List<Libro>> GetLibroAsync();
        Task<Libro?> GetLibroById(int libroId);
    }
}

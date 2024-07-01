using CPU.Models.DTOs;
using CPU.Models.Entities;
using System.Collections.Generic;

namespace CPU.Data.Repositories
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> GetAll();
        Categoria GetById(int id);
        void Add(Categoria categoria);
        void Update(Categoria categoria);
        void Delete(int id);
        void Add(CategoriaDTO categoria);
    }
}

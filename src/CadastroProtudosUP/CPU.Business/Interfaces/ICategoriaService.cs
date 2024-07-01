using CPU.Models.DTOs;
using CPU.Models.Entities;
using System.Collections.Generic;

namespace CPU.Business.Interfaces
{
    public interface ICategoriaService
    {
        IEnumerable<Categoria> GetAll();
        Categoria GetById(int id);
        void Add(Categoria categoria);
        void Update(Categoria categoria);
        void Delete(int id);
        void Update(CategoriaDTO categoriaAtualizada);
        void Add(CategoriaDTO categoria);
    }
}

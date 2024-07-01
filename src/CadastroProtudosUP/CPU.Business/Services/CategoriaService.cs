using CPU.Business.Interfaces;
using CPU.Data.Repositories;
using CPU.Models.DTOs;
using CPU.Models.Entities;
using System.Collections.Generic;

namespace CPU.Business.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public CategoriaService()
        {
        }

        public IEnumerable<Categoria> GetAll()
        {
            return _categoriaRepository.GetAll();
        }

        public Categoria GetById(int id)
        {
            return _categoriaRepository.GetById(id);
        }

        public void Add(CategoriaDTO categoria)
        {
            _categoriaRepository.Add(categoria);
        }

        public void Update(Categoria categoria)
        {
            _categoriaRepository.Update(categoria);
        }

        public void Delete(int id)
        {
            _categoriaRepository.Delete(id);
        }

        public void Update(CategoriaDTO categoriaAtualizada)
        {
            throw new System.NotImplementedException();
        }

        public void Add(Categoria categoria)
        {
            _categoriaRepository.Add(categoria);
        }
    }
}

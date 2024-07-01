using CPU.Models.Entities;
using System.Collections.Generic;

namespace CPU.Business.Interfaces
{
    public interface IProdutoService
    {
        IEnumerable<Produto> GetAll();
        Produto GetById(int id);
        void Add(Produto produto);
        void Update(Produto produto);
        void Delete(int id);
    }
}

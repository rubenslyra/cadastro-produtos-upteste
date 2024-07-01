using CPU.Models.Entities;
using System.Collections.Generic;

namespace CPU.Business.Interfaces
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> GetAll();
        Usuario GetById(int id);
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(int id);
        Usuario Authenticate(string email, string senha);
    }
}

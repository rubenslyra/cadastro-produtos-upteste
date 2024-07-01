using CPU.Models.Entities;
using System.Collections.Generic;

namespace CPU.Data.Repositories
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> GetAll();
        Usuario GetById(int id);
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(int id);
        Usuario Authenticate(string email, string senha);
    }
}

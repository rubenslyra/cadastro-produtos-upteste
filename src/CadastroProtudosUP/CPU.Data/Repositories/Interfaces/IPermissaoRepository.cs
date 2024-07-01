using CPU.Models.Entities;
using System.Collections.Generic;

namespace CPU.Data.Repositories
{
    public interface IPermissaoRepository
    {
        IEnumerable<Permissao> GetAll();
        Permissao GetById(int id);
    }
}

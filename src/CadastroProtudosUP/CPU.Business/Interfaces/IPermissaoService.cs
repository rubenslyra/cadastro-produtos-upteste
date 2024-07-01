using CPU.Models.Entities;
using System.Collections.Generic;

namespace CPU.Business.Interfaces
{
    public interface IPermissaoService
    {
        IEnumerable<Permissao> GetAll();
        Permissao GetById(int id);
    }
}

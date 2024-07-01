using CPU.Business.Interfaces;
using CPU.Data.Repositories;
using CPU.Models.Entities;
using System.Collections.Generic;

namespace CPU.Business.Services
{
    public class PermissaoService : IPermissaoService
    {
        private readonly IPermissaoRepository _permissaoRepository;

        public PermissaoService(IPermissaoRepository permissaoRepository)
        {
            _permissaoRepository = permissaoRepository;
        }

        public IEnumerable<Permissao> GetAll()
        {
            return _permissaoRepository.GetAll();
        }

        public Permissao GetById(int id)
        {
            return _permissaoRepository.GetById(id);
        }
    }
}

using CPU.Models.DTOs;
using CPU.Models.Entities;

namespace CPU.Data.Mappers
{
    public static class CategoriaMapper
    {
        public static Categoria ToEntity(CategoriaDTO categoriaDTO)
        {
            return new Categoria
            {
                CategoriaId = categoriaDTO.CategoriaId,
                Nome = categoriaDTO.Nome,
                Descricao = categoriaDTO.Descricao
            };
        }

        public static CategoriaDTO ToDTO(Categoria categoria)
        {
            return new CategoriaDTO
            {
                CategoriaId = categoria.CategoriaId,
                Nome = categoria.Nome,
                Descricao = categoria.Descricao
            };
        }
    }
}

using CPU.Models.DTOs;
using CPU.Models.Entities;

namespace CPU.Data.Mappers
{
    public static class ProdutoMapper
    {
        public static Produto ToEntity(ProdutoDTO produtoDTO)
        {
            return new Produto
            {
                ProdutoId = produtoDTO.ProdutoId,
                Nome = produtoDTO.Nome,
                Descricao = produtoDTO.Descricao,
                Preco = produtoDTO.Preco,
                Quantidade = produtoDTO.Quantidade,
                CategoriaId = produtoDTO.CategoriaId
            };
        }

        public static ProdutoDTO ToDTO(Produto produto)
        {
            return new ProdutoDTO
            {
                ProdutoId = produto.ProdutoId,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                Quantidade = produto.Quantidade,
                CategoriaId = produto.CategoriaId
            };
        }
    }
}

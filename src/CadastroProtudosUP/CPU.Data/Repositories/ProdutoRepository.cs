using CPU.Models.Entities;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CPU.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly string _connectionString;

        public ProdutoRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ProductDB"].ConnectionString;
        }

        public IEnumerable<Produto> GetAll()
        {
            var produtos = new List<Produto>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("usp_GetAllProdutos", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        produtos.Add(new Produto
                        {
                            ProdutoId = (int)reader["ProdutoId"],
                            Nome = reader["Nome"].ToString(),
                            Descricao = reader["Descricao"].ToString(),
                            Preco = (decimal)reader["Preco"],
                            Quantidade = (int)reader["Quantidade"],
                            CategoriaId = (int)reader["CategoriaId"]
                        });
                    }
                }
            }

            return produtos;
        }

        public Produto GetById(int id)
        {
            Produto produto = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("usp_GetProdutoById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ProdutoId", id);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        produto = new Produto
                        {
                            ProdutoId = (int)reader["ProdutoId"],
                            Nome = reader["Nome"].ToString(),
                            Descricao = reader["Descricao"].ToString(),
                            Preco = (decimal)reader["Preco"],
                            Quantidade = (int)reader["Quantidade"],
                            CategoriaId = (int)reader["CategoriaId"]
                        };
                    }
                }
            }

            return produto;
        }

        public void Add(Produto produto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("usp_AddProduto", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Nome", produto.Nome);
                command.Parameters.AddWithValue("@Descricao", produto.Descricao);
                command.Parameters.AddWithValue("@Preco", produto.Preco);
                command.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
                command.Parameters.AddWithValue("@CategoriaId", produto.CategoriaId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(Produto produto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("usp_UpdateProduto", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ProdutoId", produto.ProdutoId);
                command.Parameters.AddWithValue("@Nome", produto.Nome);
                command.Parameters.AddWithValue("@Descricao", produto.Descricao);
                command.Parameters.AddWithValue("@Preco", produto.Preco);
                command.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
                command.Parameters.AddWithValue("@CategoriaId", produto.CategoriaId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("usp_DeleteProduto", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ProdutoId", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}

using CPU.Models.DTOs;
using CPU.Models.Entities;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CPU.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly string _connectionString;

        public CategoriaRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ProductDB"].ConnectionString;
        }

        public IEnumerable<Categoria> GetAll()
        {
            var categorias = new List<Categoria>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("usp_GetAllCategorias", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categorias.Add(new Categoria
                        {
                            CategoriaId = (int)reader["CategoriaId"],
                            Nome = reader["Nome"].ToString(),
                            Descricao = reader["Descricao"].ToString()
                        });
                    }
                }
            }

            return categorias;
        }

        public Categoria GetById(int id)
        {
            Categoria categoria = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("usp_GetCategoriaById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CategoriaId", id);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        categoria = new Categoria
                        {
                            CategoriaId = (int)reader["CategoriaId"],
                            Nome = reader["Nome"].ToString(),
                            Descricao = reader["Descricao"].ToString()
                        };
                    }
                }
            }

            return categoria;
        }

        public void Add(Categoria categoria)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("usp_AddCategoria", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Nome", categoria.Nome);
                command.Parameters.AddWithValue("@Descricao", categoria.Descricao);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(Categoria categoria)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("usp_UpdateCategoria", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CategoriaId", categoria.CategoriaId);
                command.Parameters.AddWithValue("@Nome", categoria.Nome);
                command.Parameters.AddWithValue("@Descricao", categoria.Descricao);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("usp_DeleteCategoria", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CategoriaId", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Add(CategoriaDTO categoria)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("usp_AddCategoria", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Nome", categoria.Nome);
                command.Parameters.AddWithValue("@Descricao", categoria.Descricao);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}

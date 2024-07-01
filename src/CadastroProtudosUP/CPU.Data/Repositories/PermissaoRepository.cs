using CPU.Models.Entities;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CPU.Data.Repositories
{
    public class PermissaoRepository : IPermissaoRepository
    {
        private readonly string _connectionString;

        public PermissaoRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ProductDB"].ConnectionString;
        }

        public IEnumerable<Permissao> GetAll()
        {
            var permissoes = new List<Permissao>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("usp_GetAllPermissoes", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        permissoes.Add(new Permissao
                        {
                            PermissaoId = (int)reader["PermissaoId"],
                            Nome = reader["Nome"].ToString(),
                            Descricao = reader["Descricao"].ToString()
                        });
                    }
                }
            }

            return permissoes;
        }

        public Permissao GetById(int id)
        {
            Permissao permissao = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("usp_GetPermissaoById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@PermissaoId", id);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        permissao = new Permissao
                        {
                            PermissaoId = (int)reader["PermissaoId"],
                            Nome = reader["Nome"].ToString(),
                            Descricao = reader["Descricao"].ToString()
                        };
                    }
                }
            }

            return permissao;
        }
    }
}

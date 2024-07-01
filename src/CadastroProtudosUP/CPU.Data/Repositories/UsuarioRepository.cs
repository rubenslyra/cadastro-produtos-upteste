using CPU.Models.Entities;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CPU.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ProductDB"].ConnectionString;
        }

        public IEnumerable<Usuario> GetAll()
        {
            var usuarios = new List<Usuario>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("usp_GetAllUsuarios", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuarios.Add(new Usuario
                        {
                            UsuarioId = (int)reader["UsuarioId"],
                            Nome = reader["Nome"].ToString(),
                            Email = reader["Email"].ToString(),
                            PermissaoId = (int)reader["PermissaoId"]
                        });
                    }
                }
            }

            return usuarios;
        }

        public Usuario GetById(int id)
        {
            Usuario usuario = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("usp_GetUsuarioById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UsuarioId", id);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        usuario = new Usuario
                        {
                            UsuarioId = (int)reader["UsuarioId"],
                            Nome = reader["Nome"].ToString(),
                            Email = reader["Email"].ToString(),
                            PermissaoId = (int)reader["PermissaoId"]
                        };
                    }
                }
            }

            return usuario;
        }

        public void Add(Usuario usuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("usp_AddUsuario", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Nome", usuario.Nome);
                command.Parameters.AddWithValue("@Email", usuario.Email);
                command.Parameters.AddWithValue("@Senha", usuario.Senha);
                command.Parameters.AddWithValue("@PermissaoId", usuario.PermissaoId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(Usuario usuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("usp_UpdateUsuario", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UsuarioId", usuario.UsuarioId);
                command.Parameters.AddWithValue("@Nome", usuario.Nome);
                command.Parameters.AddWithValue("@Email", usuario.Email);
                command.Parameters.AddWithValue("@Senha", usuario.Senha);
                command.Parameters.AddWithValue("@PermissaoId", usuario.PermissaoId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("usp_DeleteUsuario", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UsuarioId", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Usuario Authenticate(string email, string senha)
        {
            Usuario usuario = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("usp_AuthenticateUsuario", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Senha", senha);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        usuario = new Usuario
                        {
                            UsuarioId = (int)reader["UsuarioId"],
                            Nome = reader["Nome"].ToString(),
                            Email = reader["Email"].ToString(),
                            PermissaoId = (int)reader["PermissaoId"]
                        };
                    }
                }
            }

            return usuario;

        }
    }
}


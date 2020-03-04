using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-J0IH97V\\SQLEXPRESS; initial catalog=InLock_Games_Tarde; integrated security=true;";


        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Retorna uma lista de usuários</returns
        public List<UsuariosDomain> Listar()
        {
            List<UsuariosDomain> usuarioDomains = new List<UsuariosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryListar = "SELECT Usuarios.IdUsuario, Usuarios.Email, Usuarios.Senha, TipoUsuario.IdTipoUsuario from Usuarios INNER JOIN TipoUsuario ON Usuarios.IdTipoUsuario = TipoUsuario.IdTipoUsuario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryListar, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuariosDomain usuarios = new UsuariosDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr[0]),
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["Senha"].ToString(),
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"])
                        };
                        usuarioDomains.Add(usuarios);
                    }
                }
            }
            return usuarioDomains;
        }

        public void Atualizar(int id, UsuariosDomain UsuarioAtualizado)
        {

        }

    
        public UsuariosDomain BuscarPorEmailSenha(string email, string senha)
        {
            // Define a conexão passando a string
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Define a query a ser executada no banco
                string querySelect = "select Usuarios.IdUsuario, Usuarios.Email, Usuarios.Senha, TipoUsuario.IdTipoUsuario, TipoUsuario.Titulo  FROM Usuarios inner join TipoUsuario on TipoUsuario.IdTipoUsuario = Usuarios.IdTipoUsuario WHERE Email = @Email AND Senha = @Senha";

                // Define o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    // Define o valor dos parâmetros
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    // Abre a conexão com o banco
                    con.Open();

                    // Executa o comando e armazena os dados no objeto rdr
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // Caso o resultado da query possua registro
                    if (rdr.Read())
                    {
                        // Instancia um objeto usuario 
                        UsuariosDomain usuario = new UsuariosDomain
                        {
                            // Atribui às propriedades os valores das colunas da tabela do banco
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["Senha"].ToString(),
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                            TipoUsuario = new TipoUsuarioDomain
                            {
                                IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                                Titulo = rdr["Titulo"].ToString()
                            }
                        };

                        // Retorna o usuario buscado
                        return usuario;
                    }
                }

                // Caso não encontre um email e senha correspondente, retorna null
                return null;
            }
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario que será cadastrado</param>
        public void Cadastrar(UsuariosDomain novoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "insert into Usuarios (Email, Senha, IdTipoUsuario) values (@Email, @Senha, @IdTIpoUsuario) ";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Email", novoUsuario.Email);
                    cmd.Parameters.AddWithValue("@Senha", novoUsuario.Senha);
                    cmd.Parameters.AddWithValue("@IdTipoUsuario", novoUsuario.IdTipoUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public UsuariosDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}





     

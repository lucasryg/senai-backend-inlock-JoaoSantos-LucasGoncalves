using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-J0IH97V\\SQLEXPRESS; initial catalog=InLock_Games_Tarde; integrated security=true;";
        public List<TipoUsuarioDomain> Listar()
        {
            List<TipoUsuarioDomain> tipoUsuarioDomains = new List<TipoUsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryListar = "select IdTipoUsuario, Titulo from TipoUsuario";

                con.Open();

                SqlDataReader rdr;

                using(SqlCommand cmd = new SqlCommand(queryListar, con))
                {
                    rdr = cmd.ExecuteReader();
                    while(rdr.Read())
                    {
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain()
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr[0]),
                            Titulo = rdr["Titulo"].ToString()
                        };

                        tipoUsuarioDomains.Add(tipoUsuario);
                    }
                }
            }
            return tipoUsuarioDomains;
        }





        public void Atualizar(int id, TipoUsuarioDomain tipoAtualizado)
        {
            throw new NotImplementedException();
        }

        public TipoUsuarioDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<TipoUsuarioDomain> BuscarPorNome(string titulo)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(TipoUsuarioDomain novoTipo)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

    }
}

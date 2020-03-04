using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string stringConexao = "Data Source=DESKTOP-J0IH97V\\SQLEXPRESS; initial catalog=InLock_Games_Tarde; integrated security=true;";

        public void Atualizar(int id, JogoDomain jogoAtualizado)
        {
            throw new NotImplementedException();
        }

        public JogoDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<JogoDomain> BuscarPorNome(string nomeJogo)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "insert into Jogo(NomeJogo, Descricao, DataDeLancamento, Valor, IdEstudio)	values(@NomeJogo,@Descricao,@Data,@Valor , @IdEstudio )";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@NomeJogo", novoJogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@Data", novoJogo.DataDeLancamento);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Jogo WHERE IdJogo = @Id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> Listar()
        {
            List<JogoDomain> jogs = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "select jogo.IdJogo, jogo.NomeJogo, jogo.Descricao, jogo.DataDeLancamento, jogo.Valor, Estudio.NomeEstudio from Jogo inner join Estudio on jogo.IdEstudio = Estudio.IdEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),
                            NomeJogo = rdr["NomeJogo"].ToString(),
                            Descricao = rdr["Descricao"].ToString(),
                            DataDeLancamento = Convert.ToDateTime(rdr["DataDeLancamento"]),
                            Valor = Convert.ToSingle(rdr["Valor"]),
                            NomeEstudio = rdr["NomeEstudio"].ToString()
                        };

                        jogs.Add(jogo);
                    }
                }
            }

            return jogs;
        }
    }
}

using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-J0IH97V\\SQLEXPRESS; initial catalog=InLock_Games_Tarde; integrated security=true;";

        public void Atualizar(int id, EstudioDomain estudioAtualizado)
        {
            throw new NotImplementedException();
        }

        public EstudioDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<EstudioDomain> BuscarPorNome(string nomeEstudio)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(EstudioDomain novoEstudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Estudio(NomeEstudio) VALUES (@NomeEstudio)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@NomeEstudio", novoEstudio.NomeEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Estudio WHERE IdEstudio = @Id";

                using (SqlCommand cmd = new SqlCommand (queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EstudioDomain> Listar()
        {
            List<EstudioDomain> estudios = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdEstudio, NomeEstudio FROM Estudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain
                        {
                            IdEstudio = Convert.ToInt32(rdr[0]),

                            NomeEstudio = rdr["NomeEstudio"].ToString()
                        };

                        estudios.Add(estudio);
                    }
                }
            }

            return estudios;
        }
    }
}

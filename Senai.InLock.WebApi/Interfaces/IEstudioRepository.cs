using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IEstudioRepository
    {   
        /// <summary>
        /// Listar os estudios
        /// </summary>
        /// <returns>Retorna uma lista com os estudios</returns>
        List<EstudioDomain> Listar();

        /// <summary>
        /// Buscar um estudio pelo seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna o estudio de acordo seu ID </returns>
        EstudioDomain BuscarPorId(int id);
        
        /// <summary>
        /// Cadastrar um estudio
        /// </summary>
        /// <param name="novoEstudio"></param>
        void Cadastrar(EstudioDomain novoEstudio);

        /// <summary>
        /// Atualizar um estudio
        /// </summary>
        /// <param name="id"></param>
        /// <param name="estudioAtualizado"></param>
        void Atualizar(int id, EstudioDomain estudioAtualizado);


        /// <summary>
        /// Deletar um estudio
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);

        /// <summary>
        /// Buscar um estudio pelo seu nome
        /// </summary>
        /// <param name="nomeEstudio"></param>
        /// <returns></returns>
        List<EstudioDomain> BuscarPorNome(string nomeEstudio);

    }
}

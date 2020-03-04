using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IJogoRepository 
    {
        /// <summary>
        /// Listar os jogos
        /// </summary>
        /// <returns>Retorna uma lista com os jogos</returns>
        List<JogoDomain> Listar();

        /// <summary>
        /// Buscar um jogo pelo seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna o jogo de acordo seu ID </returns>
        JogoDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastrar um jogo
        /// </summary>
        /// <param name="novoJogo"></param>
        void Cadastrar(JogoDomain novoJogo);

       /// <summary>
       /// 
       /// </summary>
       /// <param name="id"></param>
       /// <param name="jogoAtualizado"></param>
        void Atualizar(int id, JogoDomain jogoAtualizado);


        /// <summary>
        /// Deletar um jogo
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);

        /// <summary>
        /// Buscar um jogo pelo seu nome
        /// </summary>
        /// <param name="nomeJogo"></param>
        /// <returns></returns>
        List<JogoDomain> BuscarPorNome(string nomeJogo);
    }
}

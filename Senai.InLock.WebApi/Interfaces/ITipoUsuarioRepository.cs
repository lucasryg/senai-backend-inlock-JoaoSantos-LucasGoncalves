using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Listar os tipos de usuarios
        /// </summary>
        /// <returns>Retorna uma lista com os tipos de usuarios</returns>
        List<TipoUsuarioDomain> Listar();

        /// <summary>
        /// Buscar um tipo de usuario pelo seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna o jogo de acordo seu ID </returns>
        TipoUsuarioDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastrar um tipo de usuario
        /// </summary>
        /// <param name="novoTipo"></param>
        void Cadastrar(TipoUsuarioDomain novoTipo);

        /// <summary>
        /// Atualizar um tipo de usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipoAtualizado"></param>
        void Atualizar(int id, TipoUsuarioDomain tipoAtualizado);


        /// <summary>
        /// Deletar um tipo
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);

        /// <summary>
        /// Buscar um tipo pelo seu nome
        /// </summary>
        /// <param name="titulo"></param>
        /// <returns></returns>
        List<TipoUsuarioDomain> BuscarPorNome(string titulo);
    }
}

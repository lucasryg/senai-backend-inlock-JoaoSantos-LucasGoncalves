using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Retorna uma lista de usuários</returns>
        List<UsuariosDomain> Listar();

        /// <summary>
        /// Buscar um usuários através do ID
        /// </summary>
        /// <param name="id">ID do usuário que será buscado</param>
        /// <returns>Retorna um usuário buscado</returns>
        UsuariosDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastrar um usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario que será cadastrado</param>
        void Cadastrar(UsuariosDomain novoUsuario);

        /// <summary>
        /// Atualizar um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário que será alterado</param>
        /// <param name="UsuarioAtualizado">Objeto UsuarioAtualizado que será alterado</param>
        void Atualizar(int id, UsuariosDomain UsuarioAtualizado);

        /// <summary>
        /// Deletar um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Buscar um usuário através do e-mail e da senha
        /// </summary>
        /// <param name="email">E-mail do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Retorna um usuário validado</returns>
        UsuariosDomain BuscarPorEmailSenha(string email, string senha);
    }
}

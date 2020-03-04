using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class UsuarioController : Controller
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Retorna uma lista de usuários e um status code 200 - Ok</returns>
        /// dominio/api/Usuarios
       
        [HttpGet]
        public IActionResult Get()
        {
            // Faz a chamada para o método .Listar()
            // Retorna a lista e um status code 200 - Ok
            return Ok(_usuarioRepository.Listar());
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario que será cadastrado</param>
        /// <returns>Retorna os dados que foram enviados para cadastro e um status code 201 - Created</returns>
        /// dominio/api/Usuarios
        [HttpPost]
        public IActionResult Post(UsuariosDomain novoUsuario)
        {
            // Faz a chamada para o método .Cadastrar();
            _usuarioRepository.Cadastrar(novoUsuario);

            // Retorna o status code 201 - Created com a URI e o objeto cadastrado
            return StatusCode(200);
        }
    }
}

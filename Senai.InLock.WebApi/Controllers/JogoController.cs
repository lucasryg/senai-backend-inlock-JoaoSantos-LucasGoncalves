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

    [Route("api/[controller]")]

    [ApiController]
    public class JogoController : ControllerBase
    {
        private IJogoRepository _jogoRepository{ get; set; }

        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }

        /// <summary>
        /// Listar todos os jogos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_jogoRepository.Listar());
        }
       // so falta isso basicamente vamo pensar perai

        /// <summary>
        /// Adicionar jogo
        /// </summary>
        /// <param name="novoJogo"></param>
        /// <returns></returns>
        [Authorize(Roles = "2")]    // Somente o tipo de usuário 1 (administrador) pode acessar o endpoint   
        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
        {
            if (novoJogo.NomeJogo == null)
            {
                return BadRequest("O nome do jogo é obrigatório");
            }
            _jogoRepository.Cadastrar(novoJogo);

            return Created(StatusCode = 200, novoJogo);
        
        }

        /// <summary>
        /// Deletar um jogo pelo seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método .Deletar();
          _jogoRepository.Deletar(id);

            // Retorna um status code com uma mensagem personalizada
            return Ok("Jogo deletado");
        }


    }
}

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
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        /// <summary>
        /// Listar todos os estudios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_estudioRepository.Listar());
        }

        /// <summary>
        /// Cadastrar novo estudio
        /// </summary>
        /// <param name="novoEstudio"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            if (novoEstudio.NomeEstudio == null)
            {
                return BadRequest("O nome do estudio é obrigatório");
            }
            _estudioRepository.Cadastrar(novoEstudio);

            return Created("http://localhots:5000/Api/Estudio", novoEstudio);
        }

        
    }
}

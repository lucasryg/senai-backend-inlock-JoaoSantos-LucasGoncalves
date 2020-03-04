using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;
using Senai.InLock.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

      

        /// <summary>
        /// Fazer o login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost ]
        public IActionResult Post(LoginViewModel login)
        {
            // Busca o usuário pelo e-mail e senha
            UsuariosDomain usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login.Email, login.Senha);

            // Caso não encontre nenhum usuário com o e-mail e senha informados
            if (usuarioBuscado == null)
            {
                // Retorna NotFound com uma mensagem de erro
                return NotFound("E-mail ou senha inválidos");
    }

    // Caso o usuário seja encontrado, prossegue para a criação do token

    /*
        Instalar as dependências:

        Criar e validar o jwt
        System.IdentityModel.Tokens.Jwt(5.5.0 ou superior)

        Integrar a parte de autenticação
        Microsoft.AspNetCore.Authentication.JwtBearer(2.1.1 ou compatível com o .Net Core do projeto)
    */

    // Define os dados que serão fornecidos no token - Payload
    var claims = new[]
    {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString())
            };

    // Define a chave de acesso ao token
    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("InLock-chave-autenticacao"));

    // Define as credenciais do token - Header
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    // Gera o token
    var token = new JwtSecurityToken(
        issuer: "InLock.WebApi",                // emissor do token
        audience: "InLock.WebApi",              // destinatário do token
        claims: claims,                          // dados definidos acima
        expires: DateTime.Now.AddMinutes(30),    // tempo de expiração
        signingCredentials: creds                // credenciais do token
    );

            // Retorna Ok com o token
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }

    }
}
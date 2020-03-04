using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    public class JogoDomain
    {
        public int IdJogo { get; set; }

        [Required(ErrorMessage = "O nome do jogo é obrigatório")]
        public string NomeJogo { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A data de lançamento é obrigatória!")]
        public DateTime DataDeLancamento { get; set; }

        [Required(ErrorMessage = "O valor do jogo é obrigatório!")]
        public float Valor { get; set; }


        public string NomeEstudio { get; set; }

        public int IdEstudio { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    public class EstudioDomain
    {
        public int IdEstudio { get; set; }

        // Define que o estudio tem um nome obrigatório
        //[Required(ErrorMessage = "O nome do estudio é obrigatório")]
        public string NomeEstudio { get; set; }
    }
}

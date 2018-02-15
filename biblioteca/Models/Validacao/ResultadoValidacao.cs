using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace biblioteca.Models.Validacao
{
    public class ResultadoValidacao
    {
        public bool Valido { get; set; }
        public IEnumerable<ValidationResult> Erros { get; set; }

        public ResultadoValidacao(bool valido, IEnumerable<ValidationResult> erros)
        {
            Valido = valido;
            Erros = erros;
        }
    }
}
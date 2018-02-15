using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace biblioteca.Models.Validacao
{
    public abstract class Validador
    {
        public ResultadoValidacao Valida()
        {
            var valido = false;
            var context = new ValidationContext(this, null, null);
            var results = new List<ValidationResult>();
            if (Validator.TryValidateObject(this, context, results, true))
            {
                valido = true;
            }

            return new ResultadoValidacao(valido, results);
        }
    }
}
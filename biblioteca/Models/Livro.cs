using biblioteca.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace biblioteca.Models
{
    public class Livro : TIdentificador
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Título é obrigatório.")]
        public string Titulo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Autor é obrigatório.")]
        public string Autor { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Ano é obrigatório.")]
        [Range(0, 2100, ErrorMessage = "O campo Ano precisa ser um ano válido.")]
        public int Ano { get; set; }

    }
}
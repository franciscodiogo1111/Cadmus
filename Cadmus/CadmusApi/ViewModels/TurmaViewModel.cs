using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadmusApi.ViewModels
{
    public class TurmaViewModel
    {
        [Key]
        public int TurmaId { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Maximo {0} caracters")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracters")]
        public string NomeTurma { get; set; }
        public int QtdAlunos { get; set; }
        public DateTime DataCadastro { get; set; }
        public int EscolaId { get; set; }
        public virtual EscolaViewModel Escola { get; set; }
    }
}
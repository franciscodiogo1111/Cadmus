using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadmusApi.ViewModels
{
    public class EscolaViewModel
    {
        [Key]
        public int EscolaId { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Maximo {0} caracters")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracters")]
        public string NomeEscola { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Endereco { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public bool Ativo { get; set; }
        //public IEnumerable<TurmaViewModel> Turmas { get; set; }
    }
}
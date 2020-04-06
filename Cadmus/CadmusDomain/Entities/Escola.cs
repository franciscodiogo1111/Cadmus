using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CadmusDomain.Entities
{
    public class Escola
    {
        public int EscolaId { get; set; }
        public string NomeEscola { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Endereco { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public bool Ativo { get; set; }
        //public IEnumerable<Turma> Turmas { get; set; }
    }
}

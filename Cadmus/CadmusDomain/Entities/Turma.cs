using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadmusDomain.Entities
{
    public class Turma
    {
        public int TurmaId { get; set; }
        public string NomeTurma { get; set; }
        public int QtdAlunos { get; set; }
        public DateTime DataCadastro { get; set; }
        public int EscolaId { get; set; }
        public virtual Escola Escola { get; set; }
    }
}

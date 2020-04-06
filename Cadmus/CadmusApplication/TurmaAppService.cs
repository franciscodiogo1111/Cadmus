using CadmusApplication.Interface;
using CadmusDomain.Entities;
using CadmusDomain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadmusApplication
{
    public class TurmaAppService : AppServiceBase<Turma>, ITurmaAppService
    {
        private readonly ITurmaServices _turmaServices;
        public TurmaAppService(ITurmaServices turmaServices)
        : base(turmaServices)
        {
            _turmaServices = turmaServices;
        }


        public IEnumerable<Turma> BuscarPorIdEscola(int id)
        {
            return _turmaServices.BuscarPorIdEscola(id);
        }

        public void RemoveTurma(int id)
        {
            _turmaServices.RemoveTurma(id);
        }
    }
}

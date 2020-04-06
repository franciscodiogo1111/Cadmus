using CadmusDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadmusApplication.Interface
{
    public interface ITurmaAppService : IAppServiceBase<Turma>
    {
        IEnumerable<Turma> BuscarPorIdEscola(int id);

        void RemoveTurma(int id);
    }
}

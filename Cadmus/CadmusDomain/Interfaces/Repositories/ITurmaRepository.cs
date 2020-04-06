using CadmusDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadmusDomain.Interfaces.Repositories
{
    public interface ITurmaRepository : IRepositoryBase<Turma>
    {
        IEnumerable<Turma> BuscarPorIdEscola(int id);

        void RemoveTurma(int id);
    }
}

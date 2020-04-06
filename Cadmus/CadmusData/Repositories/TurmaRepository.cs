using CadmusDomain.Entities;
using CadmusDomain.Interfaces;
using CadmusDomain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadmusData.Repositories
{
    public class TurmaRepository : RepositoryBase<Turma>, ITurmaRepository
    {
        public IEnumerable<Turma> BuscarPorIdEscola(int id)
        {
            return db.Turmas.Where(e => e.EscolaId == id);
        }

        public void RemoveTurma(int id)
        {
            var obj = this.db.Turmas.Find(id);
            this.db.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
            this.db.SaveChanges();
        }
    }
}

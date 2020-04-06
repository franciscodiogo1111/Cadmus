using CadmusDomain.Entities;
using CadmusDomain.Interfaces.Repositories;
using CadmusDomain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace CadmusDomain.Services
{
    public class TurmaService : ServiceBase<Turma>, ITurmaServices
    {
        private readonly ITurmaRepository _turmaRepository;

        public TurmaService(ITurmaRepository turmaRepository)
            : base(turmaRepository)
        {
            _turmaRepository = turmaRepository;

        }

        public IEnumerable<Turma> BuscarPorIdEscola(int id)
        {
            return _turmaRepository.BuscarPorIdEscola(id);
        }

        public void RemoveTurma(int id)
        {
            _turmaRepository.RemoveTurma(id);
        }
    }
}

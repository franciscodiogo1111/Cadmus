using CadmusDomain.Entities;
using CadmusDomain.Interfaces.Repositories;
using CadmusDomain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadmusDomain.Services
{
    public class EscolaService : ServiceBase<Escola>, IEscolaServices
    {
        private readonly IEscolaRepository _escolaRepository;

        public EscolaService(IEscolaRepository escolaRepository)
            : base(escolaRepository)
        {
            _escolaRepository = escolaRepository;

        }
    }
}

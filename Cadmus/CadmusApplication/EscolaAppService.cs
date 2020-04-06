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
    public class EscolaAppService : AppServiceBase<Escola>, IEscolaAppService
    {
        private readonly IEscolaServices _escolaServices;

        public EscolaAppService(IEscolaServices escolaServices)
            : base(escolaServices)
        {
            _escolaServices = escolaServices;
        }
    }
}

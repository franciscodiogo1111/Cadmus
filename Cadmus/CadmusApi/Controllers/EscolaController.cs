using AutoMapper;
using CadmusApi.ViewModels;
using CadmusApplication.Interface;
using CadmusDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CadmusApi.Controllers
{
    public class EscolaController : ApiController
    {
        private readonly IEscolaAppService _escolaApp;

        public EscolaController(IEscolaAppService escolaApp)
        {
            _escolaApp = escolaApp;

        }

        [AcceptVerbs("GET")]
        [Route("ConsultarEscola")]
        public Task<HttpResponseMessage> ConsultarEscola()
        {
            var escolaViewModel = Mapper.Map<IEnumerable<Escola>, IEnumerable<EscolaViewModel>>(_escolaApp.GetAll());

            var retorno = escolaViewModel.Select(item => new EscolaViewModel
            {
                Ativo = item.Ativo,
                Cep = item.Cep,
                Cidade = item.Cidade,
                DataCadastro = item.DataCadastro,
                Endereco = item.Endereco,
                EscolaId = item.EscolaId,
                Estado = item.Estado,
                NomeEscola = item.NomeEscola
            });

            HttpResponseMessage response = new HttpResponseMessage();
            response = Request.CreateResponse(HttpStatusCode.OK, retorno);
            var result = new TaskCompletionSource<HttpResponseMessage>();
            result.SetResult(response);
            return result.Task;
        }

        [AcceptVerbs("POST")]
        [Route("CdastrarEscola")]
        public Task<HttpResponseMessage> CdastrarEscola([FromBody]EscolaViewModel escola)
        {
            if (ModelState.IsValid)
            {
                var escolaDomain = Mapper.Map<EscolaViewModel, Escola>(escola);
                _escolaApp.Add(escolaDomain);

            }

            HttpResponseMessage response = new HttpResponseMessage();
            response = Request.CreateResponse(HttpStatusCode.OK, "Sucesso");
            var result = new TaskCompletionSource<HttpResponseMessage>();
            result.SetResult(response);
            return result.Task;
        }

        [AcceptVerbs("GET")]
        [Route("ConsultarEscolaPorId/{id}")]
        public Task<HttpResponseMessage> ConsultarEscolaPorId(int id)
        {
            var retorno = _escolaApp.GetById(id);

            HttpResponseMessage response = new HttpResponseMessage();
            response = Request.CreateResponse(HttpStatusCode.OK, retorno);
            var result = new TaskCompletionSource<HttpResponseMessage>();
            result.SetResult(response);
            return result.Task;
        }

        //[AcceptVerbs("DELETE")]
        //[Route("DeletarEscola")]
        //public Task<HttpResponseMessage> DeletarEscola(int id)
        //{
        //    //var escolaDomain = Mapper.Map<EscolaViewModel, Escola>(escola);
        //    _escolaApp.Remove(id);

        //    HttpResponseMessage response = new HttpResponseMessage();
        //    response = Request.CreateResponse(HttpStatusCode.OK, "Sucesso");
        //    var result = new TaskCompletionSource<HttpResponseMessage>();
        //    result.SetResult(response);
        //    return result.Task;

        //}

        [AcceptVerbs("PUT")]
        [Route("AlterarEscola")]
        public Task<HttpResponseMessage> AlterarEscola([FromBody]EscolaViewModel escola)
        {

            var escolaDomain = Mapper.Map<EscolaViewModel, Escola>(escola);
            _escolaApp.Update(escolaDomain);

            HttpResponseMessage response = new HttpResponseMessage();
            response = Request.CreateResponse(HttpStatusCode.OK, "Sucesso");
            var result = new TaskCompletionSource<HttpResponseMessage>();
            result.SetResult(response);
            return result.Task;
        }
    }
}

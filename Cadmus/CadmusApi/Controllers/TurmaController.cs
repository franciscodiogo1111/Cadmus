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
    public class TurmaController : ApiController
    {

        private readonly ITurmaAppService _turmaAppService;

        public TurmaController(ITurmaAppService turmaAppService)
        {
            _turmaAppService = turmaAppService;

        }

        [AcceptVerbs("GET")]
        [Route("ConsultarTurma")]
        public Task<HttpResponseMessage> ConsultarTurma()
        {
            var turmaViewModel = Mapper.Map<IEnumerable<Turma>, IEnumerable<TurmaViewModel>>(_turmaAppService.GetAll());

            var retorno = turmaViewModel.Select(item => new TurmaViewModel
            {
                NomeTurma = item.NomeTurma,
                QtdAlunos = item.QtdAlunos,
                TurmaId = item.TurmaId,
                DataCadastro = item.DataCadastro,
                EscolaId = item.EscolaId
            });

            HttpResponseMessage response = new HttpResponseMessage();
            response = Request.CreateResponse(HttpStatusCode.OK, retorno);
            var result = new TaskCompletionSource<HttpResponseMessage>();
            result.SetResult(response);
            return result.Task;
        }

        [AcceptVerbs("POST")]
        [Route("CadastrarTurma")]
        public Task<HttpResponseMessage> CadastrarTurma([FromBody]TurmaViewModel turma)
        {
            if (ModelState.IsValid)
            {
                var turmaDomain = Mapper.Map<TurmaViewModel, Turma>(turma);
                _turmaAppService.Add(turmaDomain);

            }

            HttpResponseMessage response = new HttpResponseMessage();
            response = Request.CreateResponse(HttpStatusCode.OK, "Sucesso");
            var result = new TaskCompletionSource<HttpResponseMessage>();
            result.SetResult(response);
            return result.Task;
        }

        [AcceptVerbs("GET")]
        [Route("ConsultarTurmaPorId/{id}")]
        public Task<HttpResponseMessage> ConsultarTurmaPorId(int id)
        {
            var retorno = _turmaAppService.GetById(id);

            HttpResponseMessage response = new HttpResponseMessage();
            response = Request.CreateResponse(HttpStatusCode.OK, retorno);
            var result = new TaskCompletionSource<HttpResponseMessage>();
            result.SetResult(response);
            return result.Task;
        }

        [AcceptVerbs("DELETE")]
        [Route("DeletarTurma")]
        public Task<HttpResponseMessage> DeletarTurma(int id)
        {
            _turmaAppService.RemoveTurma(id);

            HttpResponseMessage response = new HttpResponseMessage();
            response = Request.CreateResponse(HttpStatusCode.OK, "Sucesso");
            var result = new TaskCompletionSource<HttpResponseMessage>();
            result.SetResult(response);
            return result.Task;

        }

        [AcceptVerbs("PUT")]
        [Route("AlterarTurma")]
        public Task<HttpResponseMessage> AlterarTurma([FromBody]TurmaViewModel turma)
        {
            var lista = new List<TurmaViewModel>();
            var filtro = this._turmaAppService.GetById(turma.TurmaId);

            filtro.QtdAlunos = turma.QtdAlunos;
            filtro.NomeTurma = filtro.NomeTurma;

            //var turmaDomain = Mapper.Map<TurmaViewModel, Turma>(turma);

            _turmaAppService.Update(filtro);

            HttpResponseMessage response = new HttpResponseMessage();
            response = Request.CreateResponse(HttpStatusCode.OK, "Sucesso");
            var result = new TaskCompletionSource<HttpResponseMessage>();
            result.SetResult(response);
            return result.Task;
        }

        [AcceptVerbs("GET")]
        [Route("ConsultarTurmaPorIdEscola/{id}")]
        public Task<HttpResponseMessage> ConsultarTurmaPorIdEscola(int id)
        {
            var retorno = _turmaAppService.BuscarPorIdEscola(id);

            HttpResponseMessage response = new HttpResponseMessage();
            response = Request.CreateResponse(HttpStatusCode.OK, retorno);
            var result = new TaskCompletionSource<HttpResponseMessage>();
            result.SetResult(response);
            return result.Task;
        }


    }
}

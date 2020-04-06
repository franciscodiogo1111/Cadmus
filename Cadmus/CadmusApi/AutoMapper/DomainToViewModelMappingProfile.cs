using AutoMapper;
using CadmusApi.ViewModels;
using CadmusDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadmusApi.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<EscolaViewModel, Escola>();
            Mapper.CreateMap<TurmaViewModel, Turma>();
        }
    }
}
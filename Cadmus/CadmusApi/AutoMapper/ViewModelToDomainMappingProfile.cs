using AutoMapper;
using CadmusApi.ViewModels;
using CadmusDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadmusApi.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Escola, EscolaViewModel>();
            Mapper.CreateMap<Turma, TurmaViewModel>();
        }
    }
}
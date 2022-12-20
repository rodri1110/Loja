using AutoMapper;
using Loja.Core.Domain;
using Loja.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Manager.Mappings
{
    public class AtualizarClienteModelViewMappingProfile : Profile
    {
        public AtualizarClienteModelViewMappingProfile()
        {
            CreateMap<AtualizarClienteModelView, Cliente>()
                .ForMember(d => d.UltimaAtualizacao, o => o.MapFrom(x => DateTime.Now))
                .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date))
                .ReverseMap();
        }
    }
}

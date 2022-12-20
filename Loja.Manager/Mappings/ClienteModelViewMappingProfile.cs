using AutoMapper;
using Loja.Core.Domain;
using Loja.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Manager.Mappings
{
    public class ClienteModelViewMappingProfile : Profile
    {
        public ClienteModelViewMappingProfile()
        {
            CreateMap<ClienteModelView, Cliente>()
                .ForMember(d => d.DataDeCriacao, o => o.MapFrom(x => DateTime.Now))
                .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date))
                .ReverseMap();

            CreateMap<EnderecoModelView, Endereco>().ReverseMap();
            CreateMap<TelefoneModelView, Telefone>().ReverseMap();
        }

    }
}

using AutoMapper;
using Loja.Core.Domain;
using Loja.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Manager.Mappings
{
    public class MedicoModelViewMappingProfile : Profile
    {
        public MedicoModelViewMappingProfile()
        {
            CreateMap<Medico, MedicoView>();
            CreateMap<NovoMedicoView, Medico>();
            CreateMap<AtualizarMedicoModelView, Medico>().ReverseMap();
            CreateMap<Especialidade, EspecialidadeModelView>().ReverseMap();
            CreateMap<Especialidade, ReferenciaEspecialidade>().ReverseMap();
        }

    }
}

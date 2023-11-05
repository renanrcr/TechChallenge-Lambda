using AutoMapper;
using TechChallenge.Api.Domain.Entities;
using TechChallenge.Api.DTOs;

namespace TechChallenge.Api.Domain.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ClienteDTO, Cliente>().ReverseMap();
            CreateMap<IdentificacaoDTO, IdentificacaoPedido>().ReverseMap();
        }
    }
}
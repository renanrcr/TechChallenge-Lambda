using AutoMapper;
using TechChallenge.Api.Domain.Entities;
using TechChallenge.Api.DTOs;

namespace TechChallenge.Api.Domain.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AutenticacaoClienteDTO, AutenticaCliente>().ReverseMap();
        }
    }
}
using AutoMapper;
using Thiesen.Application.Dtos;
using Thiesen.Domain.Entities;

namespace Thiesen.Application.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PessoaFisica, PessoaFisicaDto>();
            CreateMap<PessoaFisicaEndereco, PessoaFisicaEnderecoDto>();
            CreateMap<Contato, ContatoDto>();
            CreateMap<Endereco, EnderecoDto>();
        }
    }
}
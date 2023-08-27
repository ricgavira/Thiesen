using AutoMapper;
using Thiesen.Application.Commands.CreatePessoaFisica;
using Thiesen.Application.Commands.UpdatePessoaFisica;
using Thiesen.Application.Dtos;
using Thiesen.Domain.Entities;

namespace Thiesen.Application.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PessoaFisica, CreatePessoaFisicaCommand>();
            CreateMap<PessoaFisica, UpdatePessoaFisicaCommand>();
            CreateMap<Contato, ContatoDto>();
            CreateMap<Endereco, EnderecoDto>();
        }
    }
}
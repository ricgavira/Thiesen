using AutoMapper;
using Thiesen.Application.Commands.CreatePessoaFisica;
using Thiesen.Application.Commands.CreateUsuario;
using Thiesen.Application.Commands.UpdatePessoaFisica;
using Thiesen.Application.Commands.UpdateUsuario;
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
            CreateMap<PessoaFisica, PessoaFisicaDto>();
            CreateMap<Usuario, CreateUsuarioCommand>();            
            CreateMap<Usuario, UpdateUsuarioCommand>();
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<Contato, ContatoDto>();
            CreateMap<Endereco, EnderecoDto>();
        }
    }
}
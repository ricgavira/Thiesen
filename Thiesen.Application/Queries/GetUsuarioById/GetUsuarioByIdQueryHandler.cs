using AutoMapper;
using MediatR;
using Thiesen.Application.Dtos;
using Thiesen.Domain.Repositories;

namespace Thiesen.Application.Queries.GetUsuarioById
{
    public class GetUsuarioByIdQueryHandler : IRequestHandler<GetUsuarioByIdQuery, UsuarioDto>
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public GetUsuarioByIdQueryHandler(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UsuarioDto> Handle(GetUsuarioByIdQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<UsuarioDto>(usuario);
        }
    }
}
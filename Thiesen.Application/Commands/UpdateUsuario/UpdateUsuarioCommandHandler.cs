using AutoMapper;
using MediatR;
using Thiesen.Application.Resources;
using Thiesen.Domain.Repositories;

namespace Thiesen.Application.Commands.UpdateUsuario
{
    public class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, Unit>
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public UpdateUsuarioCommandHandler(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _repository.GetByIdAsync(request.Id);

            if (usuario == null)
                throw new KeyNotFoundException(ValidationMessages.NotFoundUsuario);

            _mapper.Map(request, usuario);

            await _repository.UpdateAsync(usuario);

            return Unit.Value;
        }
    }
}
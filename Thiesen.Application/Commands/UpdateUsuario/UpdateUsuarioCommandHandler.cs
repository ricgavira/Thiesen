using AutoMapper;
using MediatR;
using Thiesen.Application.Resources;
using Thiesen.Infra.Data.UnitOfWork;

namespace Thiesen.Application.Commands.UpdateUsuario
{
    public class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUsuarioCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _unitOfWork.UsuarioRepository.GetByIdAsync(request.Id);

            if (usuario == null)
                throw new KeyNotFoundException(ValidationMessages.NotFoundUsuario);

            _mapper.Map(request, usuario);

            await _unitOfWork.UsuarioRepository.UpdateAsync(usuario);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
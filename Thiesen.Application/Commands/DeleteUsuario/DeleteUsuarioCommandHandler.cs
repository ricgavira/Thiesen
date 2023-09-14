using MediatR;
using Thiesen.Application.Resources;
using Thiesen.Infra.Data.UnitOfWork;

namespace Thiesen.Application.Commands.DeleteUsuario
{
    public class DeleteUsuarioCommandHandler : IRequestHandler<DeleteUsuarioCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUsuarioCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _unitOfWork.UsuarioRepository.GetByIdAsync(request.Id);

            if (usuario == null)
                throw new KeyNotFoundException(ValidationMessages.NotFoundUsuario);

            await _unitOfWork.UsuarioRepository.DeleteAsync(usuario);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
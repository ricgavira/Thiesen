using AutoMapper;
using MediatR;
using Thiesen.Domain.Entities;
using Thiesen.Domain.Repositories;
using Thiesen.Domain.Services;
using Thiesen.Infra.Data.UnitOfWork;

namespace Thiesen.Application.Commands.CreateUsuario
{
    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public CreateUsuarioCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _authService = authService;
        }

        public async Task<int> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            bool usuarioExiste = await _unitOfWork.UsuarioRepository.GetByLoginAsync(request.Login);

            if (usuarioExiste)
                return -1;

            request.Password = _authService.ComputedSha256Hash(request.Password);

            var usuario = _mapper.Map<Usuario>(request);

            var retorno = await _unitOfWork.UsuarioRepository.AddAsync(usuario);
            await _unitOfWork.SaveChangesAsync();

            return retorno.Id;
        }
    }
}
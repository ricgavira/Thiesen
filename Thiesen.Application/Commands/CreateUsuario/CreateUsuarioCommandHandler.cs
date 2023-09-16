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
        private readonly IUnitOfWork<Usuario> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        private readonly IUsuarioRepository _usuarioRepository;

        public CreateUsuarioCommandHandler(IUnitOfWork<Usuario> unitOfWork, 
                                           IMapper mapper, 
                                           IAuthService authService, 
                                           IUsuarioRepository usuarioRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _authService = authService;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<int> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            bool usuarioExiste = await _usuarioRepository.GetByLoginAsync(request.Login);

            if (usuarioExiste)
                return -1;

            request.Password = _authService.ComputedSha256Hash(request.Password);

            var usuario = _mapper.Map<Usuario>(request);

            var retorno = await _unitOfWork.AddAsync(usuario);
            await _unitOfWork.SaveChangesAsync();

            return retorno.Id;
        }
    }
}
﻿using AutoMapper;
using MediatR;
using Thiesen.Application.Dtos;
using Thiesen.Domain.Repositories;

namespace Thiesen.Application.Queries.GetAllPessoasFisicas
{
    public class GetAllPessoasFisicasQueryHandler : IRequestHandler<GetAllPessoasFisicasQuery, List<PessoaFisicaDto>>
    {
        private readonly IPessoaFisicaRepository _repository;
        private readonly IMapper _mapper;

        public GetAllPessoasFisicasQueryHandler(IPessoaFisicaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<PessoaFisicaDto>> Handle(GetAllPessoasFisicasQuery request, CancellationToken cancellationToken)
        {
            var pessoasFisicas = await _repository.GetAllAsync();

            return _mapper.Map<List<PessoaFisicaDto>>(pessoasFisicas);
        }
    }
}
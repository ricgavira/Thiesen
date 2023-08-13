using AutoMapper;
using FluentValidation;
using Thiesen.Application.Dtos;
using Thiesen.Application.Services.Interfaces;
using Thiesen.Domain.Entities;
using Thiesen.Domain.Repositories;

namespace Thiesen.Application.Services
{
    public class PessoaFisicaService : IPessoaFisicaService
    {
        private readonly IPessoaFisicaRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<PessoaFisicaDto> _validator;

        public PessoaFisicaService(IPessoaFisicaRepository repository, IMapper mapper, IValidator<PessoaFisicaDto> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<PessoaFisicaDto> CreateAsync(PessoaFisicaDto pessoaFisicaDto)
        {
            var validationResult = _validator.Validate(pessoaFisicaDto);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var pessoaFisica = _mapper.Map<PessoaFisica>(pessoaFisicaDto);

            var retorno = await _repository.AddAsync(pessoaFisica);

            return _mapper.Map<PessoaFisicaDto>(retorno);
        }

        public async Task DeleteAsync(int id)
        {
            var pessoaFisica = await _repository.GetByIdAsync(id);

            if (pessoaFisica == null)
                throw new ValidationException("Pessoa Física Inexistente!");

            await _repository.DeleteAsync(pessoaFisica);
        }

        public async Task<IEnumerable<PessoaFisicaDto>> GetAllAsync()
        {
            var pessoasFisicas = await _repository.GetAllAsync();

            return _mapper.Map<List<PessoaFisicaDto>>(pessoasFisicas);
        }

        public async Task<PessoaFisicaDto> GetByIdAsync(int id)
        {
            var pessoaFisica = await _repository.GetByIdAsync(id);

            return _mapper.Map<PessoaFisicaDto>(pessoaFisica);
        }

        public async Task UpdateAsync(PessoaFisicaDto pessoaFisicaDto)
        {
            var validationResult = _validator.Validate(pessoaFisicaDto);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var pessoaFisica = await _repository.GetByIdAsync(pessoaFisicaDto.Id);

            if (pessoaFisica == null)
                throw new ValidationException("Pessoa Física Inexistente!");

            _mapper.Map(pessoaFisicaDto, pessoaFisica);

            await _repository.UpdateAsync(pessoaFisica);
        }
    }
}
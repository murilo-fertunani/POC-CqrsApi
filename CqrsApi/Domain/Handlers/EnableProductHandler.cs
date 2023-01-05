using AutoMapper;
using CqrsApi.Domain.Commands.Requests;
using CqrsApi.Domain.Commands.Responses;
using CqrsApi.Domain.Handlers.Interfaces;
using CqrsApi.Infra.Repositories.Interfaces;

namespace CqrsApi.Domain.Handlers
{
    public class EnableProductHandler : IEnableProductHandler
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public EnableProductHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EnableProductResponse> HandleAsync(EnableProductRequest command)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null)
                return null;

            entity.IsActive = true;
            entity = await _repository.UpdateAsync(entity);

            return _mapper.Map<EnableProductResponse>(entity);
        }
    }
}
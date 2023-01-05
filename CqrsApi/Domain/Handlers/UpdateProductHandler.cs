using AutoMapper;
using CqrsApi.Domain.Commands.Requests;
using CqrsApi.Domain.Commands.Responses;
using CqrsApi.Domain.Handlers.Interfaces;
using CqrsApi.Infra.Repositories.Interfaces;

namespace CqrsApi.Domain.Handlers
{
    public class UpdateProductHandler : IUpdateProductHandler
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public UpdateProductHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateProductResponse> HandleAsync(UpdateProductRequest command)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null)
                return null;

            entity = _mapper.Map(command, entity);
            entity = await _repository.UpdateAsync(entity);

            return _mapper.Map<UpdateProductResponse>(entity);
        }
    }
}
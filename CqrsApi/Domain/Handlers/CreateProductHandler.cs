using AutoMapper;
using CqrsApi.Domain.Commands.Requests;
using CqrsApi.Domain.Commands.Responses;
using CqrsApi.Domain.Entities;
using CqrsApi.Domain.Handlers.Interfaces;
using CqrsApi.Infra.Repositories.Interfaces;

namespace CqrsApi.Domain.Handlers
{
    public class CreateProductHandler : ICreateProductHandler
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public CreateProductHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateProductResponse> HandleAsync(CreateProductRequest command)
        {
            var entity = _mapper.Map<ProductEntity>(command);

            entity = await _repository.AddAsync(entity);

            return _mapper.Map<CreateProductResponse>(entity);
        }
    }
}
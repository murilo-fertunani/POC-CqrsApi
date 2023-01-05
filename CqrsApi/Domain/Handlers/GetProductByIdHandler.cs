using AutoMapper;
using CqrsApi.Domain.Handlers.Interfaces;
using CqrsApi.Domain.Queries.Requests;
using CqrsApi.Domain.Queries.Responses;
using CqrsApi.Infra.Repositories.Interfaces;

namespace CqrsApi.Domain.Handlers
{
    public class GetProductByIdHandler : IGetProductByIdHandler
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetProductByIdHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetProductByIdResponse> HandleAsync(GetProductByIdRequest command)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            return _mapper.Map<GetProductByIdResponse>(entity);
        }
    }
}
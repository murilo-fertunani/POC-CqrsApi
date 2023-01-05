using AutoMapper;
using CqrsApi.Domain.Handlers.Interfaces;
using CqrsApi.Domain.Queries.Requests;
using CqrsApi.Domain.Queries.Responses;
using CqrsApi.Infra.Repositories.Interfaces;

namespace CqrsApi.Domain.Handlers
{
    public class GetAllProductsHandler : IGetAllProductsHandler
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProductsHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllProductsResponse>> HandleAsync(GetAllProductsRequest command)
        {
            var entities = await _repository.GetAllAsync(command);

            return _mapper.Map<IEnumerable<GetAllProductsResponse>>(entities);
        }
    }
}
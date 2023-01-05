using CqrsApi.Domain.Queries.Requests;
using CqrsApi.Domain.Queries.Responses;

namespace CqrsApi.Domain.Handlers.Interfaces
{
    public interface IGetAllProductsHandler
    {
        Task<IEnumerable<GetAllProductsResponse>> HandleAsync(GetAllProductsRequest command);
    }
}
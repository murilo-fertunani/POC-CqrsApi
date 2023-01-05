using CqrsApi.Domain.Queries.Requests;
using CqrsApi.Domain.Queries.Responses;

namespace CqrsApi.Domain.Handlers.Interfaces
{
    public interface IGetProductByIdHandler
    {
        Task<GetProductByIdResponse> HandleAsync(GetProductByIdRequest command);
    }
}
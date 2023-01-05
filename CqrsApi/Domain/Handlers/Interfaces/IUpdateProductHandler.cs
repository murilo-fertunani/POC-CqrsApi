using CqrsApi.Domain.Commands.Requests;
using CqrsApi.Domain.Commands.Responses;

namespace CqrsApi.Domain.Handlers.Interfaces
{
    public interface IUpdateProductHandler
    {
        Task<UpdateProductResponse> HandleAsync(UpdateProductRequest command);
    }
}
using CqrsApi.Domain.Commands.Requests;
using CqrsApi.Domain.Commands.Responses;

namespace CqrsApi.Domain.Handlers.Interfaces
{
    public interface IDisableProductHandler
    {
        Task<DisableProductResponse> HandleAsync(DisableProductRequest command);
    }
}
using CqrsApi.Domain.Commands.Requests;
using CqrsApi.Domain.Commands.Responses;

namespace CqrsApi.Domain.Handlers.Interfaces
{
    public interface ICreateProductHandler
    {
        Task<CreateProductResponse> HandleAsync(CreateProductRequest command);
    }
}
using AutoMapper;
using CqrsApi.Domain.Commands.Requests;
using CqrsApi.Domain.Entities;

namespace CqrsApi.Common.Mappers
{
    public class RequestToEntity : Profile
    {
        public RequestToEntity()
        {
            CreateMap<CreateProductRequest, ProductEntity>();
            CreateMap<UpdateProductRequest, ProductEntity>();
        }
    }
}
using AutoMapper;
using CqrsApi.Domain.Entities;
using CqrsApi.Domain.Queries.Requests;

namespace CqrsApi.Common.Mappers
{
    public class EntityToResponse : Profile
    {
        public EntityToResponse()
        {
            CreateMap<ProductEntity, GetProductByIdRequest>();
        }
    }
}
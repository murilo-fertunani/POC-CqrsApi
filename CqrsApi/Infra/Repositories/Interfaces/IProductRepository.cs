using CqrsApi.Domain.Entities;
using CqrsApi.Domain.Queries.Requests;

namespace CqrsApi.Infra.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<ProductEntity> GetByIdAsync(Guid id, bool asNoTracking = true);
        Task<IEnumerable<ProductEntity>> GetAllAsync(GetAllProductsRequest filter, bool asNoTracking = true);
        Task<ProductEntity> AddAsync(ProductEntity entity);
        Task<ProductEntity> UpdateAsync(ProductEntity entity);
    }
}
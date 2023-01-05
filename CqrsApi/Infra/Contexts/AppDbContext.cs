using CqrsApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CqrsApi.Infra.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
    }
}
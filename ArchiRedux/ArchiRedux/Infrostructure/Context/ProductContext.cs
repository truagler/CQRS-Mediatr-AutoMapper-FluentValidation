using ArchiRedux.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace ArchiRedux.Infrostructure.Context
{
    public sealed class ProductContext: DbContext
    {
        public DbSet<Product> Product { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}
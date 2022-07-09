using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArchiRedux.Domain.Model;

namespace ArchiRedux.Application.Service
{
    public interface IProductService
    {
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task<Product> GetProductById(Guid id);
        Task<List<Product>> GetProducts();
    }
}
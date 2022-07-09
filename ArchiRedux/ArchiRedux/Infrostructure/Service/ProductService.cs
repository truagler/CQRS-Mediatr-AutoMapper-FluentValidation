using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArchiRedux.Application.Service;
using ArchiRedux.Domain.Model;
using ArchiRedux.Domain.Service;

namespace ArchiRedux.Infrostructure.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            await Task.Run(() => _productRepository.AddProduct(product));
        }

        public async Task UpdateProduct(Product product)
        {
            await Task.Run(() => _productRepository.UpdateProduct(product));
        }

        public Task<Product> GetProductById(Guid id)
        {
            return Task.FromResult(_productRepository.GetProductById(id).Result);
        }

        public Task<List<Product>> GetProducts()
        {
            return Task.FromResult(_productRepository.GetProducts().Result);
        }
    }
}
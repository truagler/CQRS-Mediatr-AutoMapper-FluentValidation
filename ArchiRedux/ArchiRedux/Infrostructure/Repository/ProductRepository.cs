using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArchiRedux.Domain.Model;
using ArchiRedux.Domain.Service;
using ArchiRedux.Infrostructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ArchiRedux.Infrostructure.Repository
{
    public class ProductRepository: IProductRepository
    {
        private readonly ProductContext _db;

        public ProductRepository(ProductContext db)
        {
            _db = db;
        }

        public async Task AddProduct(Product product)
        {
            await Task.Run(() => _db.Product.AddAsync(product));
            await SaveChanges();
        }

        public async Task UpdateProduct(Product product)
        {
            Product prod = await _db.Product.FirstOrDefaultAsync(pro => pro.Id == product.Id);
            if (prod != null)
            {
                prod.Name = product.Name;
                prod.Price = product.Price;
            }
            await SaveChanges();
        }
        
        private async Task SaveChanges()
        {
            await Task.Run(() => _db.SaveChangesAsync());
        }

        public Task<Product> GetProductById(Guid id)
        {
            Task<Product> prod =  _db.Product.FirstOrDefaultAsync(pro => pro.Id == id);
            
            if (prod.Result != null)
            {
                return prod;
            }

            return null;
        }

        public Task<List<Product>> GetProducts()
        {
            return _db.Product.ToListAsync();
        }
    }
}
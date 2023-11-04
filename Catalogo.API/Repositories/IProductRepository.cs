﻿using Catalogo.API.Entities;

namespace Catalogo.API.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> Getproducts();
        Task<Product> GetProduct(string id);
        Task<IEnumerable<Product>> GetProductsByName(string name);
        Task<IEnumerable<Product>> GetProductsByCategory(string categoryName);
        Task CreateProduct(Product product);    
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(string id);
    }
}

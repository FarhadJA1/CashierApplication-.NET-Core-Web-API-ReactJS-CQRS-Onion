﻿using B.Repository.Repositories.Interfaces;
using Domain.Entities;

namespace B.Repository.Repositories.Implementations;
public class ProductRepository : IProductRepository
{
    public Task CreateAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Product entity)
    {
        throw new NotImplementedException();
    }
}
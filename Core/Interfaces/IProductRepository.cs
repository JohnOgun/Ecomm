using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Interfaces;

namespace Core.Interfaces;

public interface IProductRepository
{
    Task<IReadOnlyList<Product>> GetProductsAsync(string? brand, string? type, string? sort); //the ? means that this is optional

    Task<Product> GetProductIdAsync(int id);

    Task<IReadOnlyList<string>> GetTypesAsync();

    Task<IReadOnlyList<string>> GetBrandsAsync();

    void AddProduct(Product product);

    void UpdateProduct(Product product);

    void DeleteProduct(Product product);

    bool ProductExists (int id);

    Task<bool> SaveChangesAsync();



}

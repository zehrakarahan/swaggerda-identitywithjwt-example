using SwaggerDeneme.JwtandSwaggerSon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerDeneme.JwtandSwaggerSon.Repository.ProductRepository
{
    public interface IProductRepository
    {
        Task<int> ApplyChangesAsync();
        IQueryable<Product> GetQueryable();

        Product InsertAsync(Product entity);
    }
}

using SwaggerDeneme.Webbbapi.Data;
using SwaggerDeneme.Webbbapi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerDeneme.Webbbapi.Repository.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;

        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> ApplyChangesAsync()
        {
            return await _dataContext.SaveChangesAsync();
        }

        public IQueryable<Product> GetQueryable()
        {

            return _dataContext.Products.AsQueryable();//.Include(oe => oe.Floors);
        }

        public Product InsertAsync(Product entity)
        {
            _dataContext.Products.Add(entity);
            _dataContext.SaveChanges();
            return entity;
        }
    }
}

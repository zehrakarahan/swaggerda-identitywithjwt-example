using SwaggerDeneme.Webbbapi.Data;
using SwaggerDeneme.Webbbapi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerDeneme.Webbbapi.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> ApplyChangesAsync()
        {
            return await _dataContext.SaveChangesAsync();
        }

        public IQueryable<User> GetQueryable()
        {
            return _dataContext.Userr;//.Include(oe => oe.Floors);
        }




        public async Task InsertAsync(User entity)
        {
            await _dataContext.Userr.AddAsync(entity);
            _dataContext.SaveChanges();
        }


    }
}

using SwaggerDeneme.SonDeneme.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerDeneme.SonDeneme.Repository.UserRepository
{
    public interface IUserRepository
    {
        Task<int> ApplyChangesAsync();
        IQueryable<User> GetQueryable();

        Task InsertAsync(User entity);
    }
}

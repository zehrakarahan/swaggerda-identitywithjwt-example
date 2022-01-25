using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwaggerDeneme.SonDeneme.Model;
using SwaggerDeneme.SonDeneme.Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerDeneme.SonDeneme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct(User user)
        {
            _userRepository.InsertAsync(user);

            return Ok(user);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Getir()
        {
            return _userRepository.GetQueryable().ToList();
        }
    }
}

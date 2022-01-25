using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwaggerDeneme.Webbbapi.Model;
using SwaggerDeneme.Webbbapi.Repository.ProductRepository;
using SwaggerDeneme.Webbbapi.Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerDeneme.Webbbapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public IProductRepository _productRepository;
        public IUserRepository _userRepository;
        public AccountController(IProductRepository productRepository, IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        //private string[] sehirler = new string[] { "antalya", "eskisehir", "istanbul" };
        //[HttpGet()]
        //public string[] Index()
        //{
        //    return sehirler;
        //}
        //public string[] Login()
        //{
        //    return sehirler;
        //}
        [HttpGet("/api/Product/deneme")]
        public async Task<IActionResult> ProductGetAll()
        {
            var data = _productRepository.GetQueryable();
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest("hatali işlem");
            }
        }
        [HttpPost("ProductInsert")]
        public async Task<IActionResult> CreateProduct([FromBody] User user)
        {
            _userRepository.InsertAsync(user);
            return Ok(user);

        }
    }
}

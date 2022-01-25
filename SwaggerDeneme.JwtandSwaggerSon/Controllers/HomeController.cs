using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SwaggerDeneme.JwtandSwaggerSon.IdentityAuth;
using SwaggerDeneme.JwtandSwaggerSon.Model.WebModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerDeneme.JwtandSwaggerSon.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        public HomeController(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager,
         IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
       [HttpPost]
       [Route("register")]
       public async Task<IActionResult> Register([FromBody]RegisterModel model)
       {
            var userExits = await _userManager.FindByNameAsync(model.UserName);
            if (userExits!=null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error",Message="User Already exits!" });
            }
            else
            {
                ApplicationUser applicationUser = new ApplicationUser()
                {
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.UserName

                };
                var result = await _userManager.CreateAsync(applicationUser,model.Password);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Creation failed! Please check user details & try again." });
                }
                return Ok(new Response {Status="Success",Message="User created Successfully!" });
            }
       }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExits = await _userManager.FindByNameAsync(model.UserName);
            if (userExits != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Already exits!" });
            }
            else
            {
                ApplicationUser applicationUser = new ApplicationUser()
                {
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.UserName

                };
                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Creation failed! Please check user details & try again." });
                }
                if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                }
                if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                }
                if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await _userManager.AddToRoleAsync(applicationUser, UserRoles.Admin);
                }
                if (await _roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await _userManager.AddToRoleAsync(applicationUser, UserRoles.User);
                }
                return Ok(new Response { Status = "Success", Message = "User created Successfully!" });
            }
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel model) 
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user!=null && await _userManager.CheckPasswordAsync(user,model.Password))
            {
                var useroles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };
                foreach (var item in useroles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role,item));
                }
                var authsigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
                var token = new JwtSecurityToken(
                    issuer:_configuration["Jwt:ValidIssuer"],
                    audience:_configuration["Jwt:ValidAudience"],
                    expires:DateTime.Now.AddHours(3),
                    claims:authClaims,
                    signingCredentials:new SigningCredentials(authsigningKey,SecurityAlgorithms.HmacSha256)
                    
                    );
                return Ok(new {token=new JwtSecurityTokenHandler().WriteToken(token),expiration=token.ValidTo });
            }
            return Unauthorized();
        }
    }
}

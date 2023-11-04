using BusinessObjects.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using xAPI.Dto.Account;

namespace xAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        [HttpPost]
        [AllowAnonymous] //Allow unauthenticated access to the specific endpoint
        public IResult Login([FromBody] LoginRequest request)
        {
            bool loggedIn = accountRepository.Login(request.Email, request.Password);

            if (loggedIn)
            {
                IConfiguration configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .Build();

                //Create token
                var issuer = configuration["Security:Issuer"];
                var audience = configuration["Security:Audience"];
                var key = Encoding.UTF8.GetBytes(configuration["Security:Key"]);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                                                                    new Claim("Id", Guid.NewGuid().ToString()),
                                                                    new Claim(JwtRegisteredClaimNames.Sub, request.Email),
                                                                    new Claim(JwtRegisteredClaimNames.Email, request.Email),
                                                                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                                                }),

                    Expires = DateTime.UtcNow.AddMinutes(3),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);

                var tokenString = tokenHandler.WriteToken(token);
                return Results.Ok(tokenString);
            }
            else
            {
                return Results.Unauthorized();
            }
        }
    }
}

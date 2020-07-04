using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using HotChocolate.AspNetCore.Authorization;
using Library.Data.Helpers;
using Library.Data.Models;
using Library.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Library.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository _repository;

        public LoginController(IConfiguration configuration, IRepository repository)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public bool ValidateUser(Login credentials)
        {
            var user = _repository.GetUser(credentials.Username);
            var hashedPassword = user.Password;
            var correctPassword = BCrypt.Net.BCrypt.Verify(credentials.Password, hashedPassword);
            return user.Username != null && correctPassword;
        }

        public string GenerateToken(Reader reader)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)),
                new Claim("Id", reader.Readerid.ToString()),
                new Claim("Email", reader.Email),
                new Claim("FirstName", reader.Firstname),
                new Claim("LastName", reader.Lastname),
                new Claim("Address", reader.Address),
                new Claim("Zipcode", reader.Zipcode),
                new Claim("Rtype", reader.Rtype),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.Now.AddHours(3), signingCredentials: signIn);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Login credentials)
        {
            var valid = ValidateUser(credentials);
            if (!valid)
                return BadRequest("Invalid credentials");
            var reader = _repository.GetReader(credentials.Username);
            var token = GenerateToken(reader);
            return Ok(new { Jwt = token });
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var readerId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value ??
                                     throw new InvalidOperationException());
            var currentUser = new Reader
            {
                Readerid = readerId,
                Email = User.Claims.FirstOrDefault(c => c.Type == "Email")?.Value,
                Firstname = User.Claims.FirstOrDefault(c => c.Type == "FirstName")?.Value,
                Lastname = User.Claims.FirstOrDefault(c => c.Type == "LastName")?.Value,
                Address = User.Claims.FirstOrDefault(c => c.Type == "Address")?.Value,
                Zipcode = User.Claims.FirstOrDefault(c => c.Type == "Zipcode")?.Value,
                Borrows = _repository.GetBorrowed(readerId)
            };
            return Ok(currentUser);
        }
    }
}

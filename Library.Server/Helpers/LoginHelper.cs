using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Library.Data.Helpers;
using Library.Data.Models;
using Library.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Library.Server.Helpers
{
    public class LoginHelper : ILoginHelper
    {
        private IRepository _repository;
        private IConfiguration _configuration;

        public LoginHelper(IRepository repository, IConfiguration configuration)
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
    }
}
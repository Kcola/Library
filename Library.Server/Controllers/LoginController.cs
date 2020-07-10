using System;
using System.Linq;
using HotChocolate.AspNetCore.Authorization;
using Library.Data.Helpers;
using Library.Data.Models;
using Library.Server.Helpers;
using Library.Shared;
using Microsoft.AspNetCore.Mvc;
using Reader = Library.Data.Models.Reader;

namespace Library.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ILoginHelper _loginHelper;


        public LoginController(ILoginHelper loginHelper, IRepository repository)
        {
            _loginHelper = loginHelper;
            _repository = repository;
        }


        [HttpPost]
        public IActionResult Post([FromBody] Login credentials)
        {
            var valid = _loginHelper.ValidateUser(credentials);
            if (!valid)
                return BadRequest("Invalid credentials");
            var reader = _repository.GetReader(credentials.Username);
            var token = _loginHelper.GenerateToken(reader);
            var value = new Token { Jwt = token };
            return Ok(value);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();
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

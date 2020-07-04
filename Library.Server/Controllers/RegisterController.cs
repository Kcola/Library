using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Library.Data.Helpers;
using Library.Data.Models;
using Library.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Library.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly IRepository _repository;

        public RegisterController(IRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Register credentials) //TODO: Create Exceptions
        {
            if (!credentials.AreValid()) return BadRequest("Invalid Credentials");
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(credentials.Password);
            var reader = new Reader()
            {
                Email = credentials.Email,
                Rtype = credentials.Type,
                Firstname = credentials.Firstname,
                Lastname = credentials.Lastname,
                Address = credentials.Address,
                Zipcode = credentials.Zipcode,
            };

            var readerAdded = await _repository.AddReader(reader);
            if (!readerAdded) return BadRequest("Invalid Credentials");

            var user = new Users()
            {
                Readerid = reader.Readerid,
                Username = credentials.Username,
                Password = passwordHash,
                Email = credentials.Email,
                Firstname = credentials.Firstname,
                Lastname = credentials.Lastname,
                Role = credentials.Role
            };

            var userAdded = await _repository.AddUser(user);
            if (!userAdded) return BadRequest("Invalid Credentials");

            return Ok(new
            {
                Username = user.Username,
                Readerid = reader.Readerid,
                Email = reader.Email,
                Firstname = reader.Firstname,
                Lastname = reader.Lastname,
                Address = reader.Address,
                Zipcode = reader.Zipcode,
            });
        }
    }
}

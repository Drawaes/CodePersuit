using CodePersuit.Service.Core.Data;
using CodePersuit.Service.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CodePersuit.Service.Core.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepo;

        public UserController(IUserRepository userRepo) => _userRepo = userRepo;

        [HttpGet("{userName}")]
        [ProducesResponseType(200, Type = typeof(User))]
        public async Task<ActionResult> Get(string userName)
        {

            var user = await _userRepo.GetUserByName(userName);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        public Task<IEnumerable<User>> Get() => _userRepo.GetAllUsers();
    }
}

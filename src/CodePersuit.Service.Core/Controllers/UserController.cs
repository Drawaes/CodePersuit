using CodePersuit.Service.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CodePersuit.Service.Core.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("{userName}")]
        [ProducesResponseType(200, Type = typeof(User))]
        public ActionResult Get(string userName)
        {
            if (userName == "Drawaes")
            {
                return Ok(new User()
                {
                    Name = "Drawaes"
                });
            }
            return NotFound();
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return new User[]
                {
                    new User()
                    {
                        Name = "Drawaes"
                    },
                    new User()
                    {
                        Name = "Qwack"
                    }
                };
        }
    }
}

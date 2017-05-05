using CodePersuit.Service.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePersuit.Service.Core.Controllers
{
    [Route("api/{userName}/[controller]")]
    public class RepoController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Repo> Get(string userName)
        {
            return null;
        }

        [HttpGet("{repoName}")]
        public Repo Get(string userName, string repoName)
        {
            return null;
        }
    }
}

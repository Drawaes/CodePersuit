using CodePersuit.Service.Core.Data;
using CodePersuit.Service.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodePersuit.Service.Core.Controllers
{
    [Route("api/user/{userName}/[controller]")]
    public class RepoController : ControllerBase
    {
        private IRepoRepository _repoRepo;

        public RepoController(IRepoRepository repoRepo) => _repoRepo = repoRepo;

        [HttpGet]
        public Task<IEnumerable<Repo>> Get(string userName) => _repoRepo.GetAllReposForUser(userName);

        [HttpGet("{repoName}")]
        [ProducesResponseType(typeof(Repo), 200)]
        public async Task<ActionResult> Get(string userName, string repoName)
        {
            var repo = await _repoRepo.GetRepoByUserAndName(userName, repoName);
            if (repo == null)
            {
                return NotFound();
            }
            return Ok(repo);
        }
    }
}

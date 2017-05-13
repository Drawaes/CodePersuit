using System;
using System.Collections.Generic;
using System.Text;
using CodePersuit.Service.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CodePersuit.Service.Core.Controllers
{
    [Route("api/{username}/repo/{reponame}")]
    public class CodeCoverageController : ControllerBase
    {
        [HttpPut("{checkinHash}")]
        [SwaggerOperation("PutCoverageFile")]
        public ActionResult ProcessCoverageFile(string username, string reponame, string checkinHash, [FromBody] CodeCoverageFile fileToProcess)
        {
            throw new NotImplementedException();
        }
    }
}

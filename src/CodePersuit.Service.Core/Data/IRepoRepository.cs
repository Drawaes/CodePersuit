using System.Collections.Generic;
using System.Threading.Tasks;
using CodePersuit.Service.Core.Models;

namespace CodePersuit.Service.Core.Data
{
    public interface IRepoRepository
    {
        Task<IEnumerable<Repo>> GetAllReposForUser(string username);
        Task<Repo> GetRepoByUserAndName(string username, string repoName);
    }
}
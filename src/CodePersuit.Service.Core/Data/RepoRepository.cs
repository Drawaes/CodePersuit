using CodePersuit.Service.Core.Models;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CodePersuit.Service.Core.Data
{
    public class RepoRepository : IRepoRepository
    {
        private readonly IOptions<DapperConfig> _config;

        private static readonly string _objectQuery = $"SELECT {nameof(Repo.RepositoryId)}, {nameof(Repo.Name)}, {nameof(Repo.OwnerId)} FROM Repository";
        private static readonly string _objectQueryByUser = _objectQuery + $" r INNER JOIN [User] u on u.UserId=r.OwnerId WHERE u.{nameof(User.Username)} like @{nameof(User.Username)}";
        private static readonly string _objectQueryByUserAndName = _objectQueryByUser + $" and r.{nameof(Repo.Name)} like @{nameof(Repo.Name)}";

        public RepoRepository(IOptions<DapperConfig> config) => _config = config ?? throw new ArgumentNullException(nameof(config));

        public async Task<IEnumerable<Repo>> GetAllReposForUser(string username)
        {
            using (var conn = new SqlConnection(_config.Value.ConfigurationString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<Repo>(_objectQueryByUser, new { Username = username });
            }
        }

        public async Task<Repo> GetRepoByUserAndName(string username, string repoName)
        {
            using (var conn = new SqlConnection(_config.Value.ConfigurationString))
            {
                await conn.OpenAsync();
                return await conn.QueryFirstOrDefaultAsync<Repo>(_objectQueryByUserAndName, new { Username = username, Name = repoName });
            }
        }
    }
}

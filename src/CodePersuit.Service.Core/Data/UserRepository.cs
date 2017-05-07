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
    public class UserRepository : IUserRepository
    {
        private static readonly string _objectQuery = $"SELECT {nameof(User.UserId)}, {nameof(User.Username)} FROM [User]";
        private static readonly string _objectQueryByName = _objectQuery + $" WHERE {nameof(User.Username)} = @{nameof(User.Username)}";

        private readonly IOptions<DapperConfig> _config;

        public UserRepository(IOptions<DapperConfig> config) => _config = config ?? throw new ArgumentNullException(nameof(config));

        public async Task<User> GetUserByName(string username)
        {
            using (var conn = new SqlConnection(_config.Value.ConfigurationString))
            {
                await conn.OpenAsync();
                return await conn.QueryFirstOrDefaultAsync<User>(_objectQueryByName, username);
            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            using (var conn = new SqlConnection(_config.Value.ConfigurationString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<User>(_objectQuery);
            }
        }
    }
}

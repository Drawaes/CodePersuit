using System.Collections.Generic;
using System.Threading.Tasks;
using CodePersuit.Service.Core.Models;

namespace CodePersuit.Service.Core.Data
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserByName(string username);
    }
}
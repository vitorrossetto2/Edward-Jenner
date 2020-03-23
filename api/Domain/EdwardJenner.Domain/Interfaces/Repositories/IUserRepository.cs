using System.Collections.Generic;
using System.Threading.Tasks;
using EdwardJenner.Models.Models;

namespace EdwardJenner.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<IList<User>> ListByNearAsync(double longitude, double latitude, int distance);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using EdwardJenner.Models.Models;

namespace EdwardJenner.Domain.Interfaces.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<IList<Order>> ListByNearAsync(double longitude, double latitude, int distance);
    }
}

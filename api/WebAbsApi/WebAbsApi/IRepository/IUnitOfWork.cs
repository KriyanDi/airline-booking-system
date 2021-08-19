using System.Threading.Tasks;
using WebAbsApi.Data;

namespace WebAbsApi.IRepository
{
    public interface IUnitOfWork
    {
        IGenericRepository<Airport> Airports { get; }
        IGenericRepository<Airline> Airlines { get; }

        Task Save();
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerRegistration.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetCustomers();
        Task<T> Get(int? id);
        void Add(T model);
        void Update(T model);
        void Remove(T model);
    }
}
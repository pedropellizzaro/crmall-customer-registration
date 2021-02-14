using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerRegistration.Application.Services.Interfaces
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetCustomers();
        Task<T> Get(int? id);
        void Add(T model);
        void Update(T model);
        void Remove(int? id);
    }
}

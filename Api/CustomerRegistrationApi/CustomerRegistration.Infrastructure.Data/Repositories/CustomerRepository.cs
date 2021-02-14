using CustomerRegistration.Domain.Entities;
using CustomerRegistration.Domain.Interfaces;
using CustomerRegistration.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerRegistration.Infrastructure.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        #region Fields
        private readonly ApplicationContext _context;
        #endregion

        #region Constructor
        public CustomerRepository(ApplicationContext context) => _context = context;
        #endregion

        #region Public Methods
        public void Add(Customer model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }

        public async Task<Customer> Get(int? id)
            => await _context.Customers.FindAsync(id);

        public async Task<IEnumerable<Customer>> GetCustomers()
            => await _context.Customers.ToListAsync();

        public void Remove(Customer model)
        {
            _context.Remove(model);
            _context.SaveChanges();
        }

        public void Update(Customer model)
        {
            _context.Update(model);
            _context.SaveChanges();
        }
        #endregion
    }
}
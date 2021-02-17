using AutoMapper;
using CustomerRegistration.Application.Services.Interfaces;
using CustomerRegistration.Application.ViewModels;
using CustomerRegistration.Domain.Entities;
using CustomerRegistration.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerRegistration.Application.Services
{
    public class CustomerService : ICustomerService
    {
        #region Fields
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        #endregion

        #region Public Methods
        public void Add(CustomerViewModel model)
        {
            var customerMap = _mapper.Map<Customer>(model);
            _customerRepository.Add(customerMap);
        }

        public async Task<CustomerViewModel> Get(int? id)
        {
            var customer = await _customerRepository.Get(id);
            return _mapper.Map<CustomerViewModel>(customer);
        }

        public async Task<IEnumerable<CustomerViewModel>> GetCustomers()
        {
            var customers = await _customerRepository.GetCustomers();
            return _mapper.Map<IEnumerable<CustomerViewModel>>(customers);
        }

        public void Remove(int? id)
        {
            var customer = _customerRepository.Get(id).Result;
            _customerRepository.Remove(customer);
        }

        public void Update(CustomerViewModel model)
        {
            var customerMap = _mapper.Map<Customer>(model);
            _customerRepository.Update(customerMap);
        }
        #endregion
    }
}

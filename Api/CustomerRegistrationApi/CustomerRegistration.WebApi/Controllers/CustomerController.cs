using CustomerRegistration.Application.Services.Interfaces;
using CustomerRegistration.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRegistration.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        #region Constants
        private const string MENSAGEM_CLIENTE_NÃO_ENCONTRADO = "Cliente não encontrado.";
        private const string MENSAGEM_CLIENTE_NÃO_ATUALIZADO = "Houve um erro, cliente não atualizado: ";
        #endregion

        #region Fields
        private readonly ICustomerService _customerService;
        #endregion

        #region Constructor
        public CustomerController(ICustomerService customerService)
            => _customerService = customerService;
        #endregion

        #region Public Methods
        [HttpGet]
        public async Task<IEnumerable<CustomerViewModel>> Get()
            => await _customerService.GetCustomers();

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerViewModel>> Get(int? id)
        {
            if (id is null)
                return NotFound(MENSAGEM_CLIENTE_NÃO_ENCONTRADO);

            var customer = await _customerService.Get(id);

            if (customer is null)
                return NotFound(MENSAGEM_CLIENTE_NÃO_ENCONTRADO);

            return customer;
        }

        [HttpPost]
        public ActionResult<CustomerViewModel> Post([FromBody] CustomerViewModel customer)
        {
            _customerService.Add(customer);
            return CreatedAtAction(nameof(Get), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public ActionResult<CustomerViewModel> Put(int id, [FromBody] CustomerViewModel customer)
        {
            if (id != customer.Id)
                return BadRequest(MENSAGEM_CLIENTE_NÃO_ENCONTRADO);

            try
            {
                _customerService.Update(customer);
                return CreatedAtAction(nameof(Get), new { id = customer.Id }, customer);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ MENSAGEM_CLIENTE_NÃO_ATUALIZADO }{ ex.Message }");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<CustomerViewModel> Delete(int? id)
        {
            if (id is null)
                return NotFound(MENSAGEM_CLIENTE_NÃO_ENCONTRADO);

            _customerService.Remove(id);

            return NoContent();
        }
        #endregion
    }
}
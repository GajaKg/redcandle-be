using API.Dtos.Customer;
using API.Interfaces;
using API.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerRepository.GetAllAsync();
            // var customersDto = customers.Select(s => s.ToCustomerDto());

            // return Ok(customersDto);
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);

            if (customer == null) return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerPostDto customerPostDto)
        {
            var customerModel = customerPostDto.ToCustomerFromPostDto();
            var customer = await _customerRepository.CreateAsync(customerModel);

            return CreatedAtAction(nameof(GetById), new { Id = customerModel.Id }, customerModel.ToCustomerDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, CustomerUpdateDto customerUpdateDto)
        {
            var customer = await _customerRepository.UpdateAsync(id, customerUpdateDto);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer.ToCustomerDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var customer = await _customerRepository.DeleteAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
using API.Data;
using API.Dtos.Customer;
using API.Interfaces;
using API.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ICustomerRepository _customerContext;
        public CustomerController(ApplicationDBContext dbContext, ICustomerRepository customerRepository)
        {
            _dbContext = dbContext;
            _customerContext = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerContext.GetAllAsync();
            var customersDto = customers.Select(s => s.ToCustomerDto());

            return Ok(customersDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var customer = await _customerContext.GetByIdAsync(id);

            if (customer == null) return NotFound();

            return Ok(customer.ToCustomerDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerPostDto customerPostDto)
        {
            var customerModel = customerPostDto.ToCustomerFromPostDto();
            var customer = _customerContext.CreateAsync(customerModel);

            return CreatedAtAction(nameof(GetById), new { Id = customerModel.Id }, customerModel.ToCustomerDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, CustomerUpdateDto customerUpdateDto)
        {
            var customer = await _customerContext.UpdateAsync(id, customerUpdateDto);

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
            var customer = await _customerContext.DeleteAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
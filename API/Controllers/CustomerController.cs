using API.Data;
using API.Dtos.Customer;
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
        public CustomerController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _dbContext.Customers.ToListAsync();
            var customersDto = customers.Select(s => s.ToCustomerDto());
            // .Select(s => s.ToCustomerDto()); // Select() === Map()

            return Ok(customersDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var customer = await _dbContext.Customers.FindAsync(id);

            if (customer == null) return NotFound();

            return Ok(customer.ToCustomerDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerPostDto customerPostDto)
        {
            var customerModel = customerPostDto.ToCustomerFromPostDto();
            await _dbContext.Customers.AddAsync(customerModel);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { Id = customerModel.Id }, customerModel.ToCustomerDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, CustomerUpdateDto customerUpdateDto)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            customer.Name = customerUpdateDto.Name;
            customer.Address = customerUpdateDto.Address;
            customer.Contact = customerUpdateDto.Contact;
            customer.Note = customerUpdateDto.Note;

            await _dbContext.SaveChangesAsync();

            return Ok(customer.ToCustomerDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            _dbContext.Remove(customer);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
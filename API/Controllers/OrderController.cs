using API.Dtos.Order;
using API.Interfaces;
using API.Mappers;
using API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/customer-order")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly CustomerRepository _customerRepository;

        public OrderController(IOrderRepository orderRepository, CustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var customerOrder = await _orderRepository.GetByIdAsync(id);
            if (customerOrder == null)
            {
                return NotFound("Order not found");
            }

            return Ok(customerOrder);
        }

        // [HttpPost]
        // public async Task<IActionResult> Create(int customerId, [FromBody] CustomerOrderPostDto customerOrderPostDto)
        // {
        //     var customerExist = await _customerRepository.CustomerExist(customerId);
        //     if (!customerExist)
        //     {
        //         return BadRequest("Customer Not found");
        //     }

        //     var customerOrder = customerOrderPostDto.ToCustomerOrderFromCreateCustomerDto(customerId);
        //     await _customerOrderRepository.CreateAsync(customerOrder);
        //     return CreatedAtAction(nameof(GetById), new { id = customerOrder.Id }, customerOrder.ToCustomerOrderDto());
        // }

    }
}
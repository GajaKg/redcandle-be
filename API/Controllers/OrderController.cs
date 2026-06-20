using API.Dtos.Order;
using API.Interfaces;
using API.Mappers;
using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/orders")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;

        public OrderController(IOrderRepository orderRepository, ICustomerRepository customerRepository)
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

        [HttpGet]
        [Route("client-orders/{clientId}")]
        public async Task<ActionResult<OrderDto>> GetOrdersByClientId([FromRoute] int clientId)
        {
            var orders = await _orderRepository.GetOrdersByClientIdAsync(clientId);

            if (orders == null) return NotFound();

            return Ok(orders);
        }

        [HttpGet]
        public async Task<ActionResult<OrderDto>> GetAll()
        {
            var orders = await _orderRepository.GetAllAsync();
            if (orders == null)
            {
                return NotFound("Order not found");
            }

            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderPostDto orderPostDto)
        {
            var customerExist = await _customerRepository.CustomerExist(orderPostDto.CustomerId);
            if (!customerExist)
            {
                return BadRequest("Customer Not found");
            }
            var order = orderPostDto.ToOrderFromPostOrderDto();
            await _orderRepository.CreateAsync(order);
            // var createdOrder = await _orderRepository.GetByIdAsync(order.Id);
            return CreatedAtAction(nameof(GetById), new { id = order.Id }, order.ToOrderDto());
        }

    }
}
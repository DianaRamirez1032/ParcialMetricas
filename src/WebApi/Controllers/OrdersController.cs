using Microsoft.AspNetCore.Mvc;
using Application.UseCases;
using Domain.Services;

namespace WebApi.Controllers
{

    // Se dividen los metodos de program.cs
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create([FromBody] OrderDto dto)
        {
            var uc = new CreateOrderUseCase();
            var order = uc.Execute(dto.Customer, dto.Product, dto.Quantity, dto.Price);
            return Ok(order);
        }

        [HttpGet("last")]
        public IActionResult Last()
        {
            return Ok(OrderService.LastOrders);
        }
    }

    public record OrderDto(string Customer, string Product, int Quantity, decimal Price);
}
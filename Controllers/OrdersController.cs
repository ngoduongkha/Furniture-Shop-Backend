using Furniture_Shop_Backend.Services.Orders;
using Furniture_Shop_Backend.ViewModels.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Furniture_Shop_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;
        public OrdersController(IOrdersService context)
        {
            _ordersService = context;
        }
        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] OrderCreateRequest request)
        {
            Console.WriteLine(request.UserId);
            Console.WriteLine(request.VoucherId);
            var result = await _ordersService.Create(request);
            if (!result.IsSuccessed)
                return BadRequest(result.Message);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoicebyId([FromRoute] int id)
        {
            if (id < 1) return NotFound();
            var result = await _ordersService.GetById(id);
            if (result is null) return NotFound();
            return Ok(result);
        }
        [HttpGet("paging-all")]
        public async Task<IActionResult> GetInvoicePaging([FromQuery] GetOrderPagingRequest request)
        {
            var result = await _ordersService.GetAllPaging(request);
            if (result.TotalRecords <= 0) return NotFound();
            return Ok(result);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaraShopWarehouse.Business;
using SaraShopWarehouse.Entities;

namespace SaraShowWarehouse.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public List<IOrder> Orders()
        {
            return _orderService.GetAllOrders();
        }

        [HttpPut]
        public IOrder UpdateOrder([FromBody] Order order)
        {
            return _orderService.UpdateOrder(order);
        }

        [HttpPut("{id}")]
        public IActionResult ProcessOrder(int id)
        {
            var order = _orderService.GetOrderById(id);
            _orderService.ProcessOrder(order);

            return Ok();
        }

        [HttpPost]
        public IOrder Create([FromBody] Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            return _orderService.CreateOrder(order);
        }

    }


}

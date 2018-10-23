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
    public class OrderController : Controller
    {
        private OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public List<Order> Orders()
        {
            return _orderService.GetAllOrders();
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            return Ok(_orderService.GetOrderById(id));
        }

        [HttpPost]
        public IActionResult ProcessOrder([FromBody]int id)
        {
            var order = _orderService.GetOrderById(id);
            _orderService.ProcessOrder(order);

            return Ok();
        }

    }


}

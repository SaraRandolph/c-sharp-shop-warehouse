using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaraShopWarehouse.Business;
using SaraShopWarehouse.Entities;
using SaraShopWarehouse.RazorWeb.Models;

namespace SaraShopWarehouse.RazorWeb.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrderService _os;

        public OrdersController(OrderService os)
        {
            _os = os;
        }

        // GET: Orders
        public IActionResult Index()
        {
            return View(_os.GetAllOrders());
        }

        // GET: Orders/Details/5
        public IActionResult Details(int id)
        {
            var order = _os.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orderes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                IOrder o = _os.CreateOrder(order);
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        //// GET: Orders/Edit/5
        public IActionResult Edit(int id)
        {
            var order = _os.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        //// POST: Order/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,ProductDescription,ProductAmount")] Order order)
        {
            _os.UpdateOrder(order);
            return View(order);
        }

     }
}

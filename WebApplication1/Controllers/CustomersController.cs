using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Entities;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class CustomersController : Controller
    {
        CustomersService service;
        public CustomersController(CustomersService service)
        {
            this.service = service;
        }
        
        [Route("")]
        public IActionResult Index()
        {
            return View(service.GetAll());
        }

        [Route("create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create(CustomersCreateVM customer)
        {
            if (!ModelState.IsValid)
                return View(customer);

            service.Add(customer);
            return RedirectToAction(nameof(Index));

        }
    }
}
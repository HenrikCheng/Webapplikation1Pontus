using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Entities;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Models
{
    public class CustomersService
    {
        readonly NorthwindContext context;

        //static int idCounter = 3;
        //List<Customer> customers = new List<Customer>
        //{
        //    new Customer { Id = 1, CompanyName = "Academy", City = "Stockholm" },
        //    new Customer { Id = 2, CompanyName = "Warm Kitten", City = "Stockholm" },
        //    new Customer { Id = 3, CompanyName = "LucasFilm", City = "Hollywood" },
        //};

        public CustomersService(NorthwindContext context)
        {
            this.context = context;
        }

        public CustomersIndexVM[] GetAll()
        {
            return context.Customer
                .OrderByDescending(o => o.CompanyName)
                .Select(o => new CustomersIndexVM
                {
                    CompanyName = o.CompanyName,
                    isVIP = o.CompanyName.StartsWith("T")
                })
                .ToArray();
        }

        internal void Add(CustomersCreateVM customer)
        {
            context.Customer.Add(new Customer
            {
                CompanyName = customer.CompanyName,
                City = customer.City
            });
            context.SaveChanges();
        }
    }
}

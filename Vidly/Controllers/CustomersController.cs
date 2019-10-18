using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        public List<Customer> GetCustomer()
        {
            var list = new List<Customer>
            {
            new Customer{Name = "Albert", Id = 1},
            new Customer {Name = "Jose", Id = 2},
            new Customer {Name = "Juan", Id = 3}
            };
            return list;
        }

        // GET: Customer
        [Route("customers")]
        public ActionResult Index()
        {

            var viewModel = new RandomMoviesViewModel
            {
                Movie = new Movie(),
                Customers = GetCustomer()
            };

            return View(viewModel);
        }

        [Route("customers/detail/{id}")]
        public ActionResult CustomerDetails(int id)
        {
            Customer retCustomer = null;
            foreach (var customer in GetCustomer())
            {
                if (customer.Id == id)
                {
                    retCustomer = customer;
                }
            }
            if (retCustomer == null)
                return HttpNotFound();

            return View(retCustomer);
        }
    }
}
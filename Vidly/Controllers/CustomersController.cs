using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private MyDbContext _context;

        public CustomersController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        [Route("customers")]
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        [Route("customers/detail/{id}")]
        public ActionResult CustomerDetails(int id)
        {
            Customer retCustomer = null;
            foreach (var customer in _context.Customers.Include(c => c.MembershipType).ToList())
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        private List<Customer> _customers = new List<Customer>
        {
            new Customer{Name = "Albert", Id = 1},
            new Customer {Name = "Jose", Id = 2},
            new Customer {Name = "Juan", Id = 3}
        };

        private readonly List<Movie> _movies = new List<Movie>
        {
            new Movie {Name = "Shrek", Id = 1},
            new Movie{Name = "John Wick", Id = 2}
        };

        [Route("movies")]
        public ActionResult Movies()
        {
            var viewModel = new MoviesViewModel
            {
                Movies = _movies
            };
            return View(viewModel);
        }

        [Route("movie/details/{id}")]
        public ActionResult MovieDetails(int id)
        {
            Movie retMovie = null;
            foreach(var movie in _movies)
            {
                if(movie.Id == id)
                {
                    retMovie = movie;
                    break;
                }
            }
            if (retMovie == null)
                return HttpNotFound();

            return View(retMovie);
        }

        [Route("customers")]
        public ActionResult Customers()
        {

            var viewModel = new RandomMoviesViewModel
            {
                Movie = new Movie(),
                Customers = _customers
            };

            return View(viewModel);
        }

        [Route("customers/detail/{id}")]
        public ActionResult CustomerDetails(int id)
        {
            Customer retCustomer = null;
            foreach(var customer in _customers)
            {
                if(customer.Id == id)
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
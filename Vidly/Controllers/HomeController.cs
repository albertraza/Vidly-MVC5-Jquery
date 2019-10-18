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

        [Route("movies")]
        public ActionResult Movies()
        {
            var viewModel = new MoviesViewModel
            {
                Movies = new Movie().GetMovies()
            };
            return View(viewModel);
        }

        [Route("movie/details/{id}")]
        public ActionResult MovieDetails(int id)
        {
            Movie retMovie = null;
            foreach(var movie in new Movie().GetMovies())
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
                Customers = new Customer().GetCustomer()
            };

            return View(viewModel);
        }

        [Route("customers/detail/{id}")]
        public ActionResult CustomerDetails(int id)
        {
            Customer retCustomer = null;
            foreach(var customer in new Customer().GetCustomer())
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
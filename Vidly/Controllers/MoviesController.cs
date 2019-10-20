using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private MyDbContext _context;

        public MoviesController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposable)
        {
            _context.Dispose();
        }

        // GET: Movie/Random
        [Route("movies/random")]
        public ActionResult Random()
        {
            var movie = new Movie
            {
                Name = "John Wick"
            };

            var customers = new List<Customer>
            {
               new Customer {Name = "Jose"},
               new Customer {Name = "Juan"},
               new Customer {Name = "Peter"}
            };

            var viewModel = new RandomMoviesViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int month, int year)
        {
            return Content(month + "/" + year);
        }

        [Route("movies/edit/{id}")]
        public ActionResult Edit(int id)
        {
            return Content("ID = " + id);
        }

        public ActionResult Details(int id)
        {
            Movie retMovie = null;
            foreach (var movie in _context.Movies.Include(m => m.Genre).ToList())
            {
                if (movie.Id == id)
                {
                    retMovie = movie;
                    break;
                }
            }
            if (retMovie == null)
                return HttpNotFound();

            return View(retMovie);
        }
    }
}
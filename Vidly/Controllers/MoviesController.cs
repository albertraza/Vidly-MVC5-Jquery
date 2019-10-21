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

        public ActionResult New()
        {
            var genreTypes = _context.GenreTypes.ToList();
            var viewModel = new MoviesFormViewModel
            {
                GenreTypes = genreTypes
            };

            return View("MoviesForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Single(m => m.Id == id);
            var viewModel = new MoviesFormViewModel
            {
                Movie = movie,
                GenreTypes = _context.GenreTypes.ToList()
            };
            return View("MoviesForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
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
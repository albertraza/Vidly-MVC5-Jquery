﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
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

        [Route("movies/{pageIndex}/{sortBy}")]
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (string.IsNullOrEmpty(sortBy))
                sortBy = "Name";

            return Content(string.Format("PageIndex = {0} SortBy = {1}", pageIndex, sortBy));
        }

        public ActionResult Movies()
        {
            return View();
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
    }
}
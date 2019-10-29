using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private MyDbContext _context;

        public RentalsController()
        {
            _context = new MyDbContext();
        }


        public IHttpActionResult GetRental()
        {
            List<byte> movies = new List<byte> { 1, 2, 3, 4, 5 };
            var rental = new RentalDto
            {
                CustomerId = 1,
                MoviesId = movies
            };

            return Ok(rental);
        }

        [HttpPost]
        public IHttpActionResult NewRental(RentalDto newRental)
        {
            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);

            var movies = _context.Movies.Where(m => newRental.MoviesId.Contains(m.Id)).Include(m => m.Genre).ToList();

            foreach (var movie in movies)
            {
                var rental = new Rental
                {
                    Customer = customer,
                    DateAdded = DateTime.Today,
                    Movie = movie
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}

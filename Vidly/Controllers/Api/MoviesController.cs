using AutoMapper;
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
    public class MoviesController : ApiController
    {
        private MyDbContext _context;

        public MoviesController()
        {
            _context = new MyDbContext();
        }

        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies
                .Include(m => m.Genre)
                .Where(m => m.NumberAvailable > 0);

            if (!string.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            var moviesDto = moviesQuery.ToList()
                .Select(Mapper.Map<Movie, MovieDto>);

            return Ok(moviesDto);
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        public IHttpActionResult NewMovie(MovieDto movie)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var movieToSave = Mapper.Map<MovieDto, Movie>(movie);

            _context.Movies.Add(movieToSave);
            _context.SaveChanges();

            movie.Id = movieToSave.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movie);
        }

        [HttpPut]
        public MovieDto UpdateMovie(int id, MovieDto movie)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Mapper.Map(movie, movieInDb);

            _context.SaveChanges();

            return movie;
        }

        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}

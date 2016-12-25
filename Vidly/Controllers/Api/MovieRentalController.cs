using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MovieRentalController : ApiController
    {
        private ApplicationDbContext _context;

        public MovieRentalController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult RentMovie(MovieRentalDto movieRental)
        {
            //if (movieRental.MovieIds.Count == 0)
                //return BadRequest("No MovieIds given ...");

            var customer = _context.Customers.Single(c => c.Id == movieRental.CustomerId);

            //if (customer == null)
                //return BadRequest("Invalid CustomerId...");

           
            var movies = _context.Movies.Where(m => movieRental.MovieIds.Contains(m.Id)).ToList();

            //if(movies.Count!=movieRental.MovieIds.Count)
                //return BadRequest("One or More Movies are Invalid..");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie not available for Rent..");
                movie.NumberAvailable--;
                var rental = new Rentals
                {
                    Customer = customer,
                    Movie = movie,
                    RentalDate = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();

        }
    }
}

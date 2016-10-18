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
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(x=>x.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(m=>m.Genre).SingleOrDefault(m => m.Id == Id);

            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        /*
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>()
            {
                new Movie {Id=1,Name="Shrek!" },
                new Movie {Id=2,Name="Lagan" }
            };
        }
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };
            var customers = new List<Customer>() {
                new Customer {Name="Customer1" },
                new Customer {Name="Customer2" }
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie=movie,
                Customers=customers

            };
            return View(viewModel);
            
        }

        
        */
    }
}
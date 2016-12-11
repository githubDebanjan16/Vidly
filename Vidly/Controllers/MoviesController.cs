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

        [Authorize(Roles =RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel() {
                Genre = genres,
                //Movie= new Movie()
            };
            return View("MovieForm",viewModel);
        }

        [Authorize(Roles =RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movieToEdit = _context.Movies.Single(m => m.Id == id);
            if (movieToEdit == null)
                return HttpNotFound();
            var viewModel = new MovieFormViewModel(movieToEdit)
            {
                    Genre = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult SaveMovie(Movie movie)
        {
           if(!ModelState.IsValid)
            {
                var genres = _context.Genres.ToList();
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genre = genres
                    
                };
                return View("MovieForm", viewModel);

            }
            if(movie.Id==0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieToUpdate = _context.Movies.Single(m => m.Id == movie.Id);

                movieToUpdate.Name = movie.Name;
                movieToUpdate.DateAdded = movie.DateAdded;
                movieToUpdate.DateReleased = movie.DateReleased;
                movieToUpdate.GenreId = movie.GenreId;
                movieToUpdate.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction ("Index", "Movies");
            
        }
        public ActionResult Index()
        {
            //var movies = _context.Movies.Include(x=>x.Genre).ToList();
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            
            return View("ReadOnlyList");
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
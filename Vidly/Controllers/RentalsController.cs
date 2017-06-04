using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class RentalsController : Controller
    {
        private ApplicationDbContext _context;
        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Rentals
        public ActionResult New()
        {
            return View();
        }

        public ActionResult ViewRentals()
        {
            var rentals = _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Movie)
                .ToList();
            return View(rentals);
        }

        public ActionResult Edit(int Id)
        {
            var rentalToEdit = _context.Rentals
                .Include(r=>r.Customer)
                .Include(r=>r.Movie)
                .Single(r => r.Id == Id);
            if (rentalToEdit == null)
                return HttpNotFound();
            var viewModel = new RentalViewModel()
            {
                Id = Id,
                Customer = rentalToEdit.Customer,
                Movie = rentalToEdit.Movie,
                RentalDate = rentalToEdit.RentalDate

            };

            return View("RentalForm", viewModel);
        }

        public ActionResult Save(RentalViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = model;
                return View("RentalForm", viewModel);
            }
            else
            {
                var rental = _context.Rentals
                    .Include(r => r.Customer)
                    .Include(r => r.Movie)
                    .Single(r => r.Id == model.Id);
                rental.ReturnDate = model.ReturnDate;
                //rental.Movie = rental.Movie;
                //rental.Customer = rental.Customer;
                //rental.RentalDate = rental.RentalDate;
            }
            _context.SaveChanges();

            return RedirectToAction("ViewRentals", "Rentals");
        }
    }
}
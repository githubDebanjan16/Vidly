﻿using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipType = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                Customer=new Customer(),
                MembershipTypes = membershipType

            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer=customer,
                    MembershipTypes=_context.MembershipTypes.ToList()

                };

                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
                
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
            
        }

        public ActionResult Edit(int id)
        {
            var customerToEdit = _context.Customers.Single(c => c.Id == id);
            if (customerToEdit == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = customerToEdit,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm",viewModel);
        }
        // GET: Customers
        public ActionResult Index()
        {
            //var customers = GetCustomers();
            //EagerLoading
            //var customers = _context.Customers.Include(c=>c.MembershipType).ToList();
            //return View(customers);
            return View();
        }

        public ActionResult Details(int Id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(x => x.Id == Id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        /*private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>() {
                new Customer {Id=1,Name="John Smith" },
                new Customer {Id=2,Name="Mary William" }
            };
        }*/

    }

}
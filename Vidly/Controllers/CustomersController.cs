﻿using System;
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
                this._context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this._context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();
            var viewModel = new IndexCustomersViewModel() { Customers = customers };
            return View(viewModel);
        }
        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
        private IEnumerable<Customer> GetCustomers()
        {
            //return  new List<Customer>();
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };
        }
    }
}
using System;
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

        List<Customer> customers;

        public CustomersController()
        {
            customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };
        }
        
        
        // GET: Customers
        public ActionResult Index()
        {
            
            var viewModel = new RandomMovieViewModel();
            viewModel.Customers = customers;
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var customer = customers.Where(c => c.Id == id).FirstOrDefault();
            if (customer == null)
            {
                return HttpNotFound();

            } else
            {
                return View(customer);

            }
        }
    }
}
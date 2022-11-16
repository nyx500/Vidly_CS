using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        
        public ActionResult NoSuchCustomer()
        {
            return View();
        }

        public ActionResult Details(int? id)
        {
            var customers = new List<Customer>
            {
                new Customer { Name = "Elias Shoehorn", Id = 0 },
                new Customer { Name = "Polly-Anne Buttersmith", Id = 1 },
                new Customer { Name = "Yannis Groomsworth", Id = 2 },
                new Customer { Name = "Ramona Skinks", Id = 3 },
                new Customer { Name = "Gretchen Barker", Id = 4 }
            };
            

            foreach (var customer in customers)
            {
                if (customer.Id == id)
                {
                    return View(customer);
                }
            }
            

            return RedirectToAction("NoSuchCustomer", "Customers");
        }

        public ActionResult Index()
        {

            var viewModel = new CustomersViewModel();

            viewModel.Customers.Add(new Customer { Name = "Elias Shoehorn", Id = 0 });
            viewModel.Customers.Add(new Customer { Name = "Polly-Anne Buttersmith", Id = 1 });
            viewModel.Customers.Add(new Customer { Name = "Yannis Groomsworth", Id = 2 });
            viewModel.Customers.Add(new Customer { Name = "Ramona Skinks", Id = 3 });
            viewModel.Customers.Add(new Customer { Name = "Gretchen Barker", Id = 4 });
            

            return View(viewModel);
        }

    }
}
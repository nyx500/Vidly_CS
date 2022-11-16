using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{   
    // A very simple class that derives from the Controller class
    public class MoviesController : Controller
    {
        

        public ActionResult NoSuchMovie()
        {
            return View();
        }

        public ActionResult Details(int? id)
        {
            var movies = new List<Movie>
            {
                new Movie
                {
                    Id = 0,
                    Name = "Shrek",
                    Description = "A movie about a romantic green ogre"
                },
                new Movie { Id = 1,
                    Name = "The Lion King",
                    Description = "Hamlet on safari"

                }
            };


            foreach (var movie in movies)
            {
                if (movie.Id == id)
                {
                    return View(movie);
                }
            }


            return RedirectToAction("NoSuchMovie", "Movies");
        }


        // GET: called when user goes to /movies/random
        // Can change ActionResult to ViewResult (better practice) if only returning once
        public ActionResult Random()
        {   
            // IRL we usually get the Movie model from a DB
            var movie = new Movie() { Name = "Shrek!", Description = "A movie about a big green ogre finding love..."};
            // this view file does not exist yet until you create it in Views
            // ALTERNATIVE: return new ViewResult();
            // Other kinds of ActionResult helper methods to return something:.....
            // return Content("Hello, World!"); for plain-text
            // return HttpNotFound(); // page is not found

            // BAD OLD WAY OF PASSING DATA TO VIEWS
            //ViewData["Movie"] = movie;
            
            // ANOTHER WAY OF PASSING DATA TO VIEWS
            // This Movie property is added to the ViewBag at runtime
            // We don't get compile-time safety
            // If we changed this Magic Property to Random Movie, we would need
            // to go back to the View and change all @ViewBag.Movie to @ViewBag.RandomMovie
            //ViewBag.Movie = movie;

            // Create list of customers
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer1" },
                new Customer { Name = "Customer2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        // Custom Route
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content("Movies released in: " + year + "/" + month);
        }

        // Needs an int id param or returns 404 
        public ActionResult Edit(int id)
        {
            return Content("id = " + id);
        }

        // OPTIONAL PARAMETERS
    // This action will be called when we navigate to the controller /Movies
        // Will return a list of movies in the database
        // If pageIndex is not specified, we display movies on page 1
        // If sortBy is not specified, we display movies by name
        // To make a parameter optional, we should make it 'nullable' by putting ? after the type
        // String is a reference type and automatically nullable
        // public ActionResult Index(int? pageIndex, string sortBy) // optional parameters
        // {
        //     if (!pageIndex.HasValue)
        //         pageIndex = 1;
        //
        //     if (String.IsNullOrWhiteSpace(sortBy))
        //         sortBy = "Name";
        //
        //     return Content(String.Format("pageIndex = {0} & sortBy = {1}", pageIndex, sortBy));
        // }

        public ActionResult Index()
        {
            var viewModel = new MoviesViewModel();
            viewModel.Movies.Add(new Movie()
            {
                Id = 0,
                Name = "Shrek",
                Description = "A movie about a romantic green ogre"
            });
            viewModel.Movies.Add(new Movie()
            {
                Id = 1,
                Name = "The Lion King",
                Description = "Hamlet on safari"
            });

            return View(viewModel);
        }
    }
}
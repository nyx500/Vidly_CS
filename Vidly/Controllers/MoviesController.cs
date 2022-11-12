using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{   
    // A very simple class that derives from the Controller class
    public class MoviesController : Controller
    {
        // GET: called when user goes to /movies/random
        public ActionResult Random()
        {   
            // IRL we usually get the Movie model from a DB
            var movie = new Movie() { Name = "Shrek!"};
            // this view file does not exist yet until you create it in Views
            return View(movie);              
        }
    }
}
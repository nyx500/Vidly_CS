using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{   
    // This is a plain old CLR class or POCO
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    // if user goes to page /movies/random, we need to create a 'movies' controller
    // with an action called 'random'
}
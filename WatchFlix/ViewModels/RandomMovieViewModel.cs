using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WatchFlix.Models;

namespace WatchFlix.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
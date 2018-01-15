using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchFlix.Models;
using WatchFlix.ViewModels;

namespace WatchFlix.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext db;
 
         public MoviesController()
         {
             db = new ApplicationDbContext();
         }
 
         protected override void Dispose(bool disposing)
         {
             db.Dispose();
         }
 
        public ViewResult Index()
        {
            var movies = db.Movies.ToList();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = db.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }

        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using WatchFlix.Migrations;
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

        public ViewResult New()
        {
            var genres = db.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = db.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = db.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var movie = db.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }

        [HttpPost]
        public ActionResult Save (Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                db.Movies.Add(movie);
            }
            else
            {
                var movieInDb = db.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            db.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}
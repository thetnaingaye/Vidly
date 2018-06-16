using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

        }
        
        
        
        // GET: Movies/Index
        public ActionResult Index()
        {

            var Movies = _context.Movies.Include(g => g.Genre).ToList();

            return View(Movies);
            //ViewData["Movie"] = movie; // old fragile way
            //ViewBag.Movie = movie; // still no safety
            //return View();

            //return Content("Hello World!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home",new { page=1,sortBy="name"});

        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var movieViewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                Genres =genres
            };
            return View("MovieForm",movieViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {

            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }

            if (movie.id == 0)
            {
                movie.DateAdded = System.DateTime.Now;
                _context.Movies.Add(movie);
            }else
            {
                var movieInDb = _context.Movies.Single(m => m.id == movie.id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
               
            }



            try
            {
                _context.SaveChanges();

            }
            catch(DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("Index","Movies");
        }

        // Movies/Edit/id
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Single(m => m.id == id);
            var genres = _context.Genres.ToList();
            var movieViewModel = new MovieFormViewModel
            {
                Movie=movie,
                Genres = genres
            };
            return View("MovieForm", movieViewModel);
        }


        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseYear(int year,int month)
        {

            return Content(year + "/" + month);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(g => g.Genre).SingleOrDefault(m => m.id == id);
            if(movie == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(movie);

            }
        }

    }
}
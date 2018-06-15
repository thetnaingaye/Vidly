using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        List<Movie> movies;

        public MoviesController()
        {
            movies = new List<Movie>
            {
                new Movie { id = 1 , Name="Shrek" },
                new Movie { id = 2 , Name="Wall-e" }
            };
        }
        
        
        
        // GET: Movies/Index
        public ActionResult Index()
        {

            var Movies = GetMovies();

            return View(Movies);
            //ViewData["Movie"] = movie; // old fragile way
            //ViewBag.Movie = movie; // still no safety
            //return View();

            //return Content("Hello World!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home",new { page=1,sortBy="name"});

        }
        // Movies/Edit/id
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }


        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseYear(int year,int month)
        {

            return Content(year + "/" + month);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return this.movies;
        }
    }
}
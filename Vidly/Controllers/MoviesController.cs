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
        
        
        
        // GET: Movies/Random
        public ActionResult Random()
        {

            var viewModel = new RandomMovieViewModel
            {
                Movies = movies
            };


            return View(viewModel);
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


        // Movies
        public ActionResult Index(int? pageIndex,string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseYear(int year,int month)
        {

            return Content(year + "/" + month);
        }
    }
}
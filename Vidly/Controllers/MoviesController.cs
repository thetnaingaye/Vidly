using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        List<Movie> movies;

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
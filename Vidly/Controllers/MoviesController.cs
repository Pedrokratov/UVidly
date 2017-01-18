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
        // GET: Movies/Random
        //public ActionResult Random()
        //{
        //    var movie = new Movie() {Name = "Shrek"};
        //    //return View(movie);
        //    //return Content("Hello World");
        //    //return HttpNotFound();
        //    //return new EmptyResult();
        //    return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name"});
        //}
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };
            ViewData["Movie"] = movie;
            ViewBag.Movie = movie;
            //var viewResult=new ViewResult();
            //viewResult.ViewData.Model = movie;
            //return viewResult;
            var customers = new List<Customer>()
            {
                new Customer() { Name="Klient 1"},
                new Customer() { Name = "Klient 2"}
            };
            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }

        public ActionResult Edit(int movieID)
        {
            return Content("Id: " + movieID);

        }
        [Route("movies/Index/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (false == pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
        //attribute routes
        //constraints: min,max,minlength,maxlengthint,float,guid
        //google ASP.NET MVC attribute route constraint 
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
        //mvcaction4 + tab   -->creates action pattern

        [Route("Movies/Index")]
        public ActionResult Index()
        {
            var movies = GetMovies();
            var viewModel = new IndexMoviesViewModel() {Movies = movies};
            return View(viewModel);
        }
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Wall-e" }
            };
        }

    }
}
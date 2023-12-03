using DotnetTP1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;

namespace DotnetTP1.Controllers
{
	public class MovieController : Controller
	{
		public IEnumerable<Movie> getAllMovies()
		{
			var movies = new List<Movie>()
			 {
			new Movie { Id = 0, Name="Die Hard", ReleaseDate = new DateTime(2005, 12,01)},
			new Movie { Id = 1, Name = "The Godfather", ReleaseDate = new DateTime(2005, 01, 01) },
			new Movie { Id = 2, Name = "HER", ReleaseDate = new DateTime(2017, 5, 10) },
			new Movie { Id = 3, Name = "The platform", ReleaseDate = new DateTime(2017, 5, 12) }
			};
			return movies;
		}


        public List<Customer> customers = new List<Customer>()
        {
            new Customer() { Id = 1,Name="Mohamed"},
            new Customer() { Id = 2,Name="Rebai"},

        };



        // GET: HomeController1
        public ActionResult Index()
		{
			List<Movie> movies = (List<Movie>)getAllMovies();
			return View(movies);
		}


        [Route("Movie/ByRelease/{month}/{year}")]
        public IActionResult ByRelease(int month, int year)
        {

            var movies = getAllMovies();

            var filtered = movies.Where(movie => (movie.ReleaseDate.Year == year && movie.ReleaseDate.Month == month)) ;

   
            ViewBag.Month = month;
            ViewBag.Year = year;

            return View(filtered);
        }

        [Route("Movie/Customers/{id}")]
        public IActionResult CustomersByMovie(int id)
		{


            

            List<Movie> movies = (List<Movie>)getAllMovies();

            var m = movies.Find(movie => movie.Id == id) ;
            if (m==null)
            {
                return Content("Movie not found");
            }
            CustomerMovieViewModel cm = new CustomerMovieViewModel
            {
                movie = m,
                customers = this.customers
            };

			return View(cm);
		}


    }
}

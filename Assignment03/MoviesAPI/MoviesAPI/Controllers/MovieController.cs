using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private MovieContext _context;
        
        public MovieController(MovieContext context)
        {
            this._context = context;
        }

        [HttpGet(Name = "Get All")]
        public ActionResult<IEnumerable<MovieItem>> GetMovieItems()
        {
            _context = HttpContext.RequestServices.GetService(typeof(MovieContext)) as MovieContext;
            return _context.GetAllMovie();
        }

        [HttpGet("{id}", Name ="Get One")]
        public ActionResult<IEnumerable<MovieItem>> GetMovieItem(string id)
        {
            _context = HttpContext.RequestServices.GetService(typeof(MovieContext)) as MovieContext;
            return _context.GetMovie(id);
        }


         [HttpPost]
         public ActionResult<IEnumerable<MovieItem>> SetMovieItem(MovieItem newMovie)
         {
            _context = HttpContext.RequestServices.GetService(typeof(MovieContext)) as MovieContext;
            return _context.SetMovie(newMovie);
         }

        [HttpPut("{id}", Name = "Update")]
        public ActionResult<IEnumerable<MovieItem>> UpdateMovieItem(string id, MovieItem movie)
        {
            _context = HttpContext.RequestServices.GetService(typeof(MovieContext)) as MovieContext;
            if(_context.GetMovie(id).Count == 0)
            {
                return NotFound("Id Not Found"); 
            } else
            {
                return _context.UpdateMovie(id, movie);
            }

            
        }

        [HttpDelete("{id}", Name = "Delete")]
        public ActionResult<IEnumerable<MovieItem>> DeleteMovieItem(string id)
        {
            _context = HttpContext.RequestServices.GetService(typeof(MovieContext)) as MovieContext;
            if (_context.DeleteMovie(id))
            {

                return Ok("Movie Deleted");
            }
            
                return NotFound("Movie with id = " + id + " Not Found");
         
        }


    }
}

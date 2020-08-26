using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab23_MoviesEntityDataBaseFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Lab23_MoviesEntityDataBaseFirst.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MoviesDbContext _context;
        public MoviesController (MoviesDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var movielist = _context.Movie.ToList();
            return View(movielist);
        }


        [HttpGet]
        public IActionResult RegisterMovie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterMovie(Movie movie)
        {
            if(ModelState.IsValid)
            {
                _context.Movie.Add(movie);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult DeleteMovie (int id)
        {
            var foundmovie = _context.Movie.Find(id);
            if(foundmovie != null)
            {
                _context.Movie.Remove(foundmovie);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}

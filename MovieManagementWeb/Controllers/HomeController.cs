using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieData.Models;
using MovieRepo.Models;
namespace MovieUILayer.Controllers
{
    public class HomeController : Controller
    {
        private Movieinterface mv;
        public HomeController(Movieinterface f)
        {
            mv = f;
        }


        public IActionResult Index()
        {
            return View(mv.GetMovies());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Movieentity m)
        {
            mv.addmovie(m);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int movieid)
        {
            mv.deletemovie(movieid);
            return RedirectToAction("Index");
        }



        public IActionResult searchid(int movieid)
        {

            return View(mv.moviebyid(movieid));
        }

        public IActionResult searchname(string moviename)
        {

            return View(mv.moviebyname(moviename));
        }
        public IActionResult searchlead(string movielead)
        {

            return View(mv.moviebylead(movielead));
        }
        public IActionResult searchrating(double movierating)
        {

            return View(mv.moviebyrating(movierating));
        }
        public IActionResult searchyear(int movieyear)
        {

            return View(mv.moviebyyear(movieyear));
        }
        public IActionResult searchlanguage(string movielanguage)
        {

            return View(mv.moviebylanguage(movielanguage));
        }
        public IActionResult searchcategory(string moviecategory)
        {

            return View(mv.moviebycategory(moviecategory));
        }
        public IActionResult Edit(int movieid)
        {
            return View(mv.moviebyid(movieid));
        }

        [HttpPost]
        public IActionResult Edit(Movieentity m)
        {
            mv.updatemovie(m);
            return RedirectToAction("Index");
        }




    }
}

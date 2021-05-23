using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieData.Models;
using MovieRepo.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace MovieUILayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webhost;
        private Movieinterface mv;
        //private Movieentity ef;
        //private Moviecontext mf;
        public HomeController(Movieinterface f, IWebHostEnvironment webhost)
        {
            mv = f;
            _webhost = webhost;
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
            string video = m.videotrailer;
            video= video.Replace("watch?v=", "embed/");
            m.videotrailer = video;
            string message="";
            foreach (IFormFile file in Request.Form.Files)
            {
                 message = imagepathcon(file);
                m.ImageData = message;
                //    MemoryStream ms = new MemoryStream();
                //    file.CopyTo(ms);
                //    byte[] a = ms.ToArray();
                //    string imageBase64Data =
                //Convert.ToBase64String(a);
                //    string imageDataURL =
                //string.Format("data:image/png;base64,{0}",
                //imageBase64Data);
                //    ViewBag.ImageDataUrl = imageDataURL;
                //    m.ImageData = imageDataURL;
                //    ms.Close();
                //    ms.Dispose();
                //    ViewBag.Message = "Image(s) stored in database!";
            }
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
            IEnumerable<Movieentity> e = mv.moviebyname(moviename);
            
            return View(e);
        }

        public IActionResult searchlead(string movielead)
        {

            return View(mv.moviebylead(movielead));
        }
        public IActionResult searchrating(double movierating)
        {

            return View(mv.moviebyrating(movierating));
        }
        public IActionResult searchyear(int movieyear1, int movieyear2)
        {
            if (movieyear2 == 0)
                movieyear2 = movieyear1;
            //or movieyear2 = 2021; -- if sid can prepopulate it, then go with above uncommented code
            return View(mv.moviebyyear(movieyear1, movieyear2));
        }
        public IActionResult searchlanguage(string movielanguage)
        {

            return View(mv.moviebylanguage(movielanguage));
        }
        public IActionResult searchcategory(string moviecategory)
        {
            return View(mv.moviebycategory(moviecategory));

        }
        //string imgdata;
        public IActionResult Edit(int movieid)
        {
            Movieentity m = mv.moviebyid(movieid);
           // imgdata = m.ImageData;
           // ViewBag.one = imgdata;
            return View(m);
        }

        [HttpPost]
        public IActionResult Edit(Movieentity m)
        {
            // ViewBag.two = imgdata;

            string video = m.videotrailer;
            video = video.Replace("watch?v=", "embed/");
            m.videotrailer = video;

            //int i = 0;
            string message = "";
                foreach (var file in Request.Form.Files)
                {
                
                message = imagepathcon(file);
                m.ImageData = message;
                //if (i == 0)
                //{
                //   // m.ImageData = message;
                //}
                //else if (i == 1)
                //{
                //   // m.ImageData2 = message;
                //}
                //else
                //{
                //   // m.ImgaeData3 = message;
                //}
                //i++;
                //    MemoryStream ms = new MemoryStream();
                //    file.CopyTo(ms);
                //    byte[] a = ms.ToArray();
                //    string imageBase64Data =
                //Convert.ToBase64String(a);
                //    string imageDataURL =
                //string.Format("data:image/png;base64,{0}",
                //imageBase64Data);
                //    ViewBag.ImageDataUrl = imageDataURL;
                //    m.ImageData = imageDataURL;
                //    ms.Close();
                //    ms.Dispose();

                
                }
                
            //if (m.ImageData != null)
            //{
            //   // m.ImageData2 = m.ImageData;
            //}
            //else
            //{
            //   // m.ImageData = m.ImageData2;
            //}
            //else
            //{
            //    m.ImageData = m.ImageData2;
            //}


            mv.updatemovie(m);
            return RedirectToAction("Index");
        }

        public string imagepathcon(IFormFile file)
        { 

        var savimg = Path.Combine(_webhost.WebRootPath, "images", file.FileName);
        string imtext = Path.GetExtension(file.FileName);
            if (imtext == ".jpg" || imtext == ".png")
            {
                using (var uploading = new FileStream(savimg, FileMode.Create))
                {
                    file.CopyToAsync(uploading);
                    return "/Images/" + file.FileName;
                };



              
            }
            return "/Images/download.png";
                }

    }
}

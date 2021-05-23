using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MovieRepo.Models;
using MovieData.Models;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using ModelsLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace moviemanagement.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        IEnumerable<Movieentity> lst;
        Movieentity obj;
        private readonly IWebHostEnvironment _webhost;
        private Movieinterface mv;
        Moviecontext c;
        public MovieController(Movieinterface f, IWebHostEnvironment webhost, Moviecontext ca)
        {
            mv = f;
            _webhost = webhost;
            c = ca;
        }

        //----------ADMIN SPECIFIC----------


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> movielist(int pageNumber=1)
        {
            //var client = new HttpClient();

            //client.BaseAddress = new Uri("http://localhost:55849/api/");

            //var resp = client.GetAsync("crud");
            //resp.Wait();
            //var res = resp.Result;
            //if (res.IsSuccessStatusCode)
            //{
            //    var read = res.Content.ReadAsAsync<IList<Movieentity>>();
            //    read.Wait();
            //    lst = read.Result;

            //}
            //return View(lst);
            return View(await PaginatedList<Movieentity>.CreateAsync(c.movieentities, pageNumber, 8));
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Createmovie()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public IActionResult Createmovie(Movieentity m)
        {
            //string video = m.videotrailer;
            //video = video.Replace("watch?v=", "embed/");
            //m.videotrailer = video;
            string message = "";
            foreach (IFormFile file in Request.Form.Files)
            {
                message = imagepathcon(file);
                m.ImageData = message;

            }
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55849/api/crud"); //address of web service(in properties-->LaunchSettings.json)

            var pst = client.PostAsJsonAsync<Movieentity>("crud", m);
            pst.Wait();

            var rs = pst.Result;

            if (rs.IsSuccessStatusCode)
            {
                return RedirectToAction("movielist");
            }

            return View(m);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55849/api/");
            var del = client.DeleteAsync("crud/" + movieid);
            del.Wait();
            var res = del.Result;
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("movielist");
            }

            return RedirectToAction("movielist");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55849/api/");
            var del = client.GetAsync("crud/" + movieid);
            del.Wait();
            var res = del.Result;
            if (res.IsSuccessStatusCode)
            {
                var read = res.Content.ReadAsAsync<Movieentity>();
                read.Wait();
                obj = read.Result;

            }

            return View(obj);

        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(Movieentity m)
        {
            //string video = m.videotrailer;
            //video = video.Replace("watch?v=", "embed/");
            //m.videotrailer = video;

            //int i = 0;
            string message = "";
            foreach (var file in Request.Form.Files)
            {

                message = imagepathcon(file);
                m.ImageData = message;
            }
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55849/api/");
            var del = client.PutAsJsonAsync<Movieentity>("crud", m);
            del.Wait();
            var res = del.Result;
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("movielist");

            }
            return RedirectToAction("movielist");


        }
        [Authorize(Roles = "Admin")]
        public IActionResult Details(int movieid)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55849/api/");
            var del = client.GetAsync("crud/" + movieid);
            del.Wait();
            var res = del.Result;
            if (res.IsSuccessStatusCode)
            {
                var read = res.Content.ReadAsAsync<Movieentity>();
                read.Wait();
                obj = read.Result;

            }

            return View(obj);

        }

        //[Authorize("Admin")]

        public IActionResult Adminsearch()
        {
            return View();
        }
        //[Authorize(Roles = "Admin")]
        public IActionResult searchadmin(string moviename)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55849/api/");
            var del = client.GetAsync("crud/" + moviename);
            del.Wait();
            var res = del.Result;
            if (res.IsSuccessStatusCode)
            {
                var read = res.Content.ReadAsAsync<IEnumerable<Movieentity>>();
                read.Wait();
                lst = read.Result;

            }


            return View(lst);
            //return View(searchstring(moviename, "moviename"));
        }


        //------------admin/customer-------------
        //[Authorize]
        public IActionResult searchname(string moviename)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55849/api/");
            var del = client.GetAsync("crud/" + moviename);
            del.Wait();
            var res = del.Result;
            if (res.IsSuccessStatusCode)
            {
                var read = res.Content.ReadAsAsync<IEnumerable<Movieentity>>();
                read.Wait();
                lst = read.Result;

            }


            return View(lst);
            //return View(searchstring(moviename, "moviename"));
        }
        //[Authorize]
        public IActionResult searchfname()
        {
            return View();
        }
      
        //[Authorize]
        public IActionResult searchlead(string movielead)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55849/api/");
            var del = client.GetAsync("crud/searchlead/"+movielead);
            del.Wait();
            var res = del.Result;
            if (res.IsSuccessStatusCode)
            {
                var read = res.Content.ReadAsAsync<IEnumerable<Movieentity>>();
                read.Wait();
                lst = read.Result;

            }
            return View(lst);



            // return View(searchstring(movielead, "movielead"));

        }
        //[Authorize]
        public IActionResult searchflead(string movielead)
        {
            return View();
        }
        //[Authorize]
        public IActionResult searchcategory(string moviecategory)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55849/api/");
            var del = client.GetAsync("crud/searchcategory/"+moviecategory);
            del.Wait();
            var res = del.Result;
            
            if (res.IsSuccessStatusCode)
            {
                var read = res.Content.ReadAsAsync<IEnumerable<Movieentity>>();
                read.Wait();
                lst = read.Result;

            }

            return View(lst);
        }
        //[Authorize]
        public IActionResult searchfcategory(string moviecategory)
        {
            return View();
        }
        //[Authorize]
        public IActionResult searchlanguage(string movielanguage)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55849/api/");
            var del = client.GetAsync("crud/searchlanguage/" + movielanguage);
            del.Wait();
            var res = del.Result;
            if (res.IsSuccessStatusCode)
            {
                var read = res.Content.ReadAsAsync<IEnumerable<Movieentity>>();
                read.Wait();
                lst = read.Result;

            }

            return View(lst);
        }
        //[Authorize]
        public IActionResult searchflanguage()
        {
           
            return View();
        }
        //[Authorize]
        ////RATING WEBAPI
        public IActionResult searchrating(double movierating)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55849/api/");
            var del = client.GetAsync("crud/searchrating/" + movierating);
            del.Wait();
            var res = del.Result;
            if (res.IsSuccessStatusCode)
            {
                var read = res.Content.ReadAsAsync<IEnumerable<Movieentity>>();
                read.Wait();
                lst = read.Result;

            }

            return View(lst);
        }
        //[Authorize]
        public IActionResult searchfrating()
        {
            return View();
        }
        //[Authorize]
        ////YEAR WEBAPI
        public IActionResult searchyear(int movieyear1, int movieyear2)
        {
            yearclass yc = new yearclass();
            yc.movieyear1 = movieyear1;
            yc.movieyear2 = movieyear2;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55849/api/");
           // var del = client.GetAsync("crud/searchyear/" + movieyear1 + movieyear2);
            var del = client.GetAsync(string.Format("crud/searchyear/", movieyear1, movieyear2));
            del.Wait();
            var res = del.Result;
            if (res.IsSuccessStatusCode)
            {
                // var read = JsonConvert.DeserializeObject<Movieentity>(Json);
                var read = res.Content.ReadAsAsync<IEnumerable<Movieentity>>();
                read.Wait();
                lst = read.Result;

            }

            return View(lst);
        }
        //[Authorize]
        public IActionResult searchfyear()
        {
            return View();
        }
        public IActionResult AboutUs()
        {

            return View();
        }
        //[Authorize]
        public IActionResult Customer()
        {

            return View();
        }
        //[Authorize]
        public IActionResult CustomerAboutUs()
        {

            return View();
        }
        //[Authorize]

        public IActionResult search()
        {
            return View();
        }
        //[Authorize]
        public IActionResult DetailsCustomer(int movieid)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55849/api/");
            var del = client.GetAsync("crud/" + movieid);
            del.Wait();
            var res = del.Result;
            if (res.IsSuccessStatusCode)
            {
                var read = res.Content.ReadAsAsync<Movieentity>();
                read.Wait();
                obj = read.Result;

            }

            return View(obj);
        }
        [AllowAnonymous]
        public IActionResult StartPage()
        {
            return View();
        }

        //------IMAGE PATH CONNECTION--------
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
            return "/Images/tom3.png";


        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieData.Models;
using MovieRepo.Models;


namespace MovieUILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private Movieinterface db;
        public CrudController(Movieinterface d)
        {
            db = d;
        }
        [HttpGet]
        public IActionResult getmovies()
        {
            try
            {
                return Ok(db.GetMovies());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            }
        }
        [HttpPost]
        public IActionResult addmovie([Microsoft.AspNetCore.Mvc.FromBody] Movieentity f)
        {

            try
            {
                if (f == null)
                {
                    return BadRequest();
                }
                db.addmovie(f);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
                //we have database server error, web api error 
            }
        }


        [HttpDelete("{movieid:int}")]
        public IActionResult deletemovie(int movieid)
        {

            if (movieid <= 0)
                return BadRequest("invalid movieid");
            else
            {
                db.deletemovie(movieid);
                return Ok();
            }
        }

        [HttpGet("{movieid:int}")]
        public ActionResult<Movieentity> getmoviebyid(int movieid)
        {
            try
            {
                Movieentity f = db.moviebyid(movieid);
                if (f == null)
                {
                    return NotFound();
                }
                return f;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            }

        }
        [HttpPut]
        public IActionResult updatemovie(Movieentity f)
        {
            try
            {
                if (f == null)
                    return BadRequest("invlid");
                else
                {
                    db.updatemovie(f);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            }
            return Ok();
        }

       // [HttpGet("[action]/{moviename}")]
       [HttpGet("{moviename}")]
        public ActionResult<IEnumerable<Movieentity>> searchname(string moviename)
        {
            try
            {
                IEnumerable<Movieentity> f = db.moviebyname(moviename);
                if (f == null)
                {
                    return NotFound();
                }
                return f.ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            }
        }
        
        [Route("[action]/{movieyear1:int}/{movieyear2:int}")]
        [HttpGet]
        public ActionResult<IEnumerable<Movieentity>> searchyear(int movieyear1, int movieyear2)
        {
            try
            {
                IEnumerable<Movieentity> f = db.moviebyyear(movieyear1, movieyear2);
                if (f == null)
                {
                    return NotFound();
                }
                return f.ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            }
        }


        [Route("[action]/{movielead}")]
        [HttpGet]
        public ActionResult<IEnumerable<Movieentity>> searchlead(string movielead)
        {
            try
            {
                IEnumerable<Movieentity> m = db.moviebylead(movielead);
                if (m == null)
                {
                    return NotFound();
                }
                return (m.ToList());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            }
        }

        // [HttpGet("[action]/{moviecategory}")]
        // //[HttpGet("{moviecategory:maxlength(40)}")]
        // // [Route("MM")]
        //// [HttpGet("[action]/{moviecategory:maxlength(30)}")]
        // //[Route("api/[controller]")]

        [Route("[action]/{moviecategory}")]
        [HttpGet]
        public ActionResult<IEnumerable<Movieentity>> searchcategory(string moviecategory)
        {
            try
            {
                IEnumerable<Movieentity> m = db.moviebycategory(moviecategory);
                if (m == null)
                {
                    return NotFound();
                }
                return (m.ToList());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            }
        }
        [Route("[action]/{movielanguage}")]
        [HttpGet]
        public ActionResult<Movieentity> searchlanguage(string movielanguage)
        {
            try
            {
                IEnumerable<Movieentity> m = db.moviebylanguage(movielanguage);
                return Ok(m);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            }
        }

        [Route("[action]/{movierating}")]
        [HttpGet]
        public ActionResult<IEnumerable<Movieentity>> searchrating(double movierating)
        {
            try
            {
                IEnumerable<Movieentity> m = db.moviebyrating(movierating);
                return Ok(m);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
            }
        }

        //[HttpGet("{moviename}")]
        //public ActionResult<IEnumerable<Movieentity>> searchname(string moviename)
        //{
        //    try
        //    {
        //        IEnumerable<Movieentity> f = db.moviebyname(moviename);
        //        if (f == null)
        //        {
        //            return NotFound();
        //        }
        //        return (f.ToList());
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
        //    }
        //}

        //[HttpGet("{searchword}/{searchcolumn}")]

        //public ActionResult<IEnumerable<Movieentity>> searchstring(string searchword, string searchcolumn)
        //{
        //    if (searchcolumn.Equals("movielead"))
        //    {
        //        try
        //        {
        //            IEnumerable<Movieentity> m = db.moviebylead(searchword);
        //            if (m == null)
        //            {
        //                return NotFound();
        //            }
        //            return (m.ToList());
        //        }
        //        catch (Exception)
        //        {
        //            return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
        //        }
        //    }
        //    else if (searchcolumn.Equals("moviename"))
        //    {
        //        try
        //        {
        //            IEnumerable<Movieentity> m = db.moviebyname(searchword);
        //            if (m == null)
        //            {
        //                return NotFound();
        //            }
        //            return (m.ToList());
        //        }
        //        catch (Exception)
        //        {
        //            return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
        //        }
        //    }
        //    else
        //        return NotFound();
        //}
        //[HttpGet("[action]/{moviecategory}")]
        //[HttpGet("{moviecategory:maxlength(40)}")]
        //[Route("MM")]
        //public ActionResult<IEnumerable<Movieentity>> searchcategory([FromUri] string moviecategory)
        //{
        //    try
        //    {
        //        IEnumerable<Movieentity> m = db.moviebycategory(moviecategory);
        //        if (m == null)
        //        {
        //            return NotFound();
        //        }
        //        return (m.ToList());
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "internal server error");
        //    }
        //}
    }
}
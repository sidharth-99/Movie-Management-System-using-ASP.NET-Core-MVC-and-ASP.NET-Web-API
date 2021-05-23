using Microsoft.EntityFrameworkCore;
using MovieData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRepo.Models
{
   public class Movieclass : Movieinterface
    {

        private Moviecontext db;
        public Movieclass(Moviecontext d)
        {
            db = d;
        }
        public void addmovie(Movieentity m)
        {
            db.movieentities.Add(m);
            db.SaveChanges();
        }

        public void deletemovie(int movieid)
        {
            Movieentity mv = db.movieentities.Find(movieid);
            db.movieentities.Remove(mv);
            db.SaveChanges();

        }

        public IEnumerable<Movieentity> GetMovies()
        {
            return db.movieentities.FromSqlRaw<Movieentity>("allmovieshow").ToList();
        }

        public IEnumerable<Movieentity> moviebycategory(string moviecategory)
        {
            return db.movieentities.FromSqlRaw<Movieentity>("search_category {0}", moviecategory).ToList();
        }

        public Movieentity moviebyid(int movieid)
        {
            return db.movieentities.Find(movieid);
        }

        public IEnumerable<Movieentity> moviebylanguage(string movielanguage)
        {
            return db.movieentities.FromSqlRaw<Movieentity>("search_language {0}", movielanguage).ToList();
        }

        public IEnumerable<Movieentity> moviebylead(string movielead)
        {
            return db.movieentities.FromSqlRaw<Movieentity>("search_lead {0}", movielead).ToList();
        }

        public IEnumerable<Movieentity> moviebyname(string moviename)
        {
            return db.movieentities.FromSqlRaw<Movieentity>("search_name {0}", moviename).ToList();
        }

        public IEnumerable<Movieentity> moviebyrating(double movierating)
        {
            return db.movieentities.FromSqlRaw<Movieentity>("search_rating {0}", movierating).ToList();
        }

        public IEnumerable<Movieentity> moviebyyear(int movieyear1, int movieyear2)
        {
            return db.movieentities.FromSqlRaw<Movieentity>("search_year {0}, {1}", movieyear1, movieyear2).ToList();
        }

        public void updatemovie(Movieentity m)
        {
            db.movieentities.Update(m);
            db.SaveChanges();
        }

    }
}

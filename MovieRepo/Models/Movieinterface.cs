using System;
using System.Collections.Generic;
using System.Text;
using MovieData.Models;
namespace MovieRepo.Models
{
   public interface Movieinterface
    {
        IEnumerable<Movieentity> GetMovies();
        IEnumerable<Movieentity> moviebyid(int movieid);
        IEnumerable<Movieentity> moviebyname(string moviename);
        IEnumerable<Movieentity> moviebylead(string movielead);
        IEnumerable<Movieentity> moviebyrating(double movierating);
        IEnumerable<Movieentity> moviebyyear(int movieyear);
        IEnumerable<Movieentity> moviebylanguage(string movielanguage);
        IEnumerable<Movieentity> moviebycategory(string moviecategory);



        public void addmovie(Movieentity m);
        public void deletemovie(int movieid);
        public void updatemovie(Movieentity m);
    }
}

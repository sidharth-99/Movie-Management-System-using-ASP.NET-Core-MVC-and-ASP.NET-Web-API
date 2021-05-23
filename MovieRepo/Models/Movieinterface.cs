using System;
using System.Collections.Generic;
using System.Text;
using MovieData.Models;

namespace MovieRepo.Models
{
   public interface Movieinterface
    {
        IEnumerable<Movieentity> GetMovies();
        Movieentity moviebyid(int movieid);
        IEnumerable<Movieentity> moviebyname(string moviename);
        IEnumerable<Movieentity> moviebylead(string movielead);
        IEnumerable<Movieentity> moviebyrating(double movierating);
        IEnumerable<Movieentity> moviebyyear(int movieyear1, int movieyear2); 
        IEnumerable<Movieentity> moviebylanguage(string movielanguage);
        IEnumerable<Movieentity> moviebycategory(string moviecategory);

        //moviebyyearasc
        //moviebyyeardesc
        //moviewithnotexactname
        //moviewithnotexactlead
        
        /*
         * functionality 1 - search with name..
         * f2 - search with lead
         * f3 - search with category
         * f4 - search with language
         * f5 - search with year
         * f6 - search with rating 
         * f7 - year with one input
         * f8 - year with two inputs
         * f9 - 
         * */
        

        public void addmovie(Movieentity m);
        public void deletemovie(int movieid);
        public void updatemovie(Movieentity m);
    }
}

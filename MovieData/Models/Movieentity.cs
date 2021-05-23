using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieData.Models
{
    public class Movieentity
    {

        [Key]
        public int movieid { get; set; }
        public string moviename { get; set; }
        public int movieyear { get; set; }
        public string moviecategory1 { get; set; }
        public string moviecategory2 { get; set; }
        public string movielanguage { get; set; } 
        public double movierating { get; set; }
        public string movielead1 { get; set; } 
        public string movielead2 { get; set; }
        public string moviedescription { get; set; } 
        public string movieduration { get; set; } 
        public string moviebudget { get; set; } 
        public string videotrailer { get; set; }
        public string ImageData { get; set; }
       

    }
}

﻿using System;
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
        public string moviecategory { get; set; }
        public string movielanguage { get; set; }
        public double movierating { get; set; }
        public string movielead { get; set; }
        public string moviedescription { get; set; }
        public string movieduration { get; set; }
        public string moviebudget { get; set; }

        //image1
        //image2
        //image3
        //videolink
    }
}

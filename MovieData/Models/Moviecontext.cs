using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieData.Models
{
    public class Moviecontext:DbContext
    {
        public Moviecontext(DbContextOptions<Moviecontext> op) : base(op)
        {

        }
        public DbSet<Movieentity> movieentities { get; set; }
      
        



    }
}

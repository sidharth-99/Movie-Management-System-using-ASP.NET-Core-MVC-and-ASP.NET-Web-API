using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CustomerReger.Models;

namespace CustomerReger.Models
{
    public class appdbcontext : IdentityDbContext<loginm>
    {
        public appdbcontext(DbContextOptions<appdbcontext> op) : base(op)
        {

        }
        public DbSet<loginm> loginm { get; set; }
        //public DbSet<appuser> appusers { get; set; }
    }
}

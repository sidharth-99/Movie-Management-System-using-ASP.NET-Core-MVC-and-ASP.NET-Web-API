using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminReger.Models
{
    public class admindbcontext : IdentityDbContext
    {
        public admindbcontext(DbContextOptions<admindbcontext> op) : base(op)
        {

        }
        public DbSet<adminlogin> adminlogins { get; set; }
        //public DbSet<appuser> appusers { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelsLibrary;

namespace MovieData.Models
{
    public class UserRolecontext : IdentityDbContext<AppUser>
    {
        public UserRolecontext(DbContextOptions<UserRolecontext> op) : base(op)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
    }
}

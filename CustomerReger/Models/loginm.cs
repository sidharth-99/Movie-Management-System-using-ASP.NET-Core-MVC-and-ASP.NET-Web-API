using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerReger.Models
{
    public class loginm : IdentityUser
    {
        public string Password { get; set; }
        public string uri { get; set; }
        public string custques { get; set; }
        public string custans { get; set; }
    }
}
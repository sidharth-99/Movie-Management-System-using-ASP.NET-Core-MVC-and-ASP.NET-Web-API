using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerReg.Models
{
    public class loginm : IdentityUser
    {
        public string Password { get; set; }
        public string uri { get; set; }
        public string custques { get; set; }
        public string custans { get; set; }
    }
}

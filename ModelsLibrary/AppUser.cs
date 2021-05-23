using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsLibrary
{
    public class AppUser : IdentityUser
    {

        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
    }
}

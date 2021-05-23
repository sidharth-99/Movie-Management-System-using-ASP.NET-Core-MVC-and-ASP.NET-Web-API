using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminReger.Models
{
    public class adminlogin 
    {

        [Key]
        public int id { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "invalid email address")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string uri { get; set; }

    }
}
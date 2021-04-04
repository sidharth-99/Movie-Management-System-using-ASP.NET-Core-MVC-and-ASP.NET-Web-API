using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieData.Models
{
    public class Adminentity
    {
        [Key]
        public int adminid { get; set; }
        public string adminname { get; set; }
        public string adminemail { get; set; }
        public string adminpassword { get; set; }
        public string adminsecque { get; set; }
        public string adminsecans { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieData.Models
{
   public class Customerentity
    {
        [Key]
        public int custid { get; set; }
        public string custname { get; set; }
        public string custemail { get; set; }
        public string custpassword { get; set; }
        public string custsecque { get; set; }
        public string custsecans { get; set; }

    }
}

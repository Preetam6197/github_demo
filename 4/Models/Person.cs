using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _4.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        public string PersonName { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }

        public string PersonCity { get; set; }

        //[ForeignKey("Role")]

        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}
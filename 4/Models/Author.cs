using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _4.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Country { get; set; }

        public string Address { get; set; }
    }
}
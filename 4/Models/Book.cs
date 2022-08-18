using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _4.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public decimal Price { get; set; }
        public string Language { get; set; }


       // [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public Author Author { get; set; }
    }
}
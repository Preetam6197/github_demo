using _4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _4.DatabaseContext
{
    public class Context:DbContext
    {
        public Context() : base("name=DataConnection")
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
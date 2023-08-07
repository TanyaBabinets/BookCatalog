using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookCatalog.Model
{
    class BookContext : DbContext
    {
        public DbSet<Book> books { get; set; }
        public DbSet<Author> authors { get; set; }
        public DbSet<PressName> pressNames { get; set; }
        public DbSet<Category> categorys { get; set; }

        public BookContext() : base("DbBook")
        {
        }


    }
}

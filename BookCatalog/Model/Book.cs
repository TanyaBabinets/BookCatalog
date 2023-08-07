using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Model
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }   
        public int Pages { get; set; }

        public virtual Author author1 { get; set; }//
  //    public virtual PressName pressname1 { get; set; }
        public virtual Category category1 { get; set; }
      
        public virtual ICollection<PressName> pressname { get; set; }

       
        public Book()
        {
            pressname = new List<PressName>();
           
           
        }
    }
}


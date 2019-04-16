using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Titulo del libro")]
        public string Name { get; set; }
        [Display(Name = "Codigo ISBN")]
        public string ISBN { get; set; }
        [Display(Name = "Autor")]
        public string Author { get; set; }
    }
}

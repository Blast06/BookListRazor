using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [TempData]
        public string Message { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;


        }

        [BindProperty]
        public Book Book { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();

            }
            // agrego el libro(lo tomo de la propiedad "book" que esta ya binded y por eso no se necesita enviar
            // por parametro en OnPost
            _db.Books.Add(Book);
            await _db.SaveChangesAsync();
            Message = "Libro creado exitosamente";
            return RedirectToPage("Index");

        }


    }
}
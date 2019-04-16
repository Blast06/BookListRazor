using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        public IEnumerable<Book> Books { get; set; }

        [TempData]
        public string Message { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _dbContext = db;

        }
        public async Task OnGet()
        {
            Books = await _dbContext.Books.ToListAsync();

        }

        //para eliminar un libro
        public async Task<IActionResult> OnPost(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();

            }

            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
            Message = "Libro eliminado exitosamente";
            return RedirectToPage("Index");
        }
    }
}
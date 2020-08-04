using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Pages.Books
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel (AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }

        public IActionResult OnGet(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Book = _context.Books.FirstOrDefault(b => b.ID == id);

            if(Book == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = _context.Books.Find(id);

            if (Book != null)
            {
                _context.Books.Remove(Book);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
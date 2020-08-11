using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.Helpers;
using WebApplication.Models;

namespace WebApplication.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = _context.Books.FirstOrDefault(b => b.ID == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(IFormFile bookImage)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Book.Image = ImageHelper.ConvertImageToByteArray(bookImage);
            _context.Attach(Book).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Book.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(b => b.ID == id);
        }
    }
}
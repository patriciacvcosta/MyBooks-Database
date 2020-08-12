using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication.Data;
using WebApplication.Helpers;
using WebApplication.Models;

namespace WebApplication.Pages.Books
{
    [RequestFormLimits(MultipartBodyLengthLimit = 268435456)]
    public class CreateModel : PageModel
    {

        private readonly AppDbContext _context; //used to query from a database and group together changes that will then be written back to the store as a unit.

        public CreateModel(AppDbContext context) //Dependency injection
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        public IActionResult OnPost(IFormFile bookImage, IFormFile bookFile)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Book.Image = FileHelper.ConvertFileToByteArray(bookImage);    
            Book.File = FileHelper.ConvertFileToByteArray(bookFile);

            _context.Books.Add(Book);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
        
    }
}
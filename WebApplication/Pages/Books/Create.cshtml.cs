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

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Books.Add(Book);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
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
    public class IndexModel : PageModel
    {

        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Book> Books { get; set; }

        public void OnGet()
        {
            Books = _context.Books.ToList();
        }
    }
}
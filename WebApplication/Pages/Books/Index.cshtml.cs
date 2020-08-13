using System;
using System.Collections.Generic;
using System.IO;
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

        public ActionResult OnPostDownloadFileFromDataBase(int id)
        {
            var _fileUpload = _context.Books.SingleOrDefault(aa => aa.ID == id);         // _fileUpload.FileContent type is byte
            MemoryStream ms = new MemoryStream(_fileUpload.File);
            //return new FileStreamResult(ms, "application/pdf");             opens the pdf in the same tab
            return new FileStreamResult(ms, "application/vnd.openxmlformats-officedocument.wordprocessingml.document");    //downloads the file

        }
    }
}
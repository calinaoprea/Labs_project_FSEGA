using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Calina_Oprea_Lab2.Data;
using Calina_Oprea_Lab2.Models;

namespace Calina_Oprea_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Calina_Oprea_Lab2Context _context;

        public IndexModel(Calina_Oprea_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; } = default!;
        public string TitleSort { get; set; }
        public string AuthorSort { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder)
        {
            if (_context.Book != null)
            {
                BookD = new BookData();

                TitleSort = String.IsNullOrEmpty(sortOrder) ? " title_desc " : "";
                AuthorSort = sortOrder == "author" ? "author_desc" : "author";
                Book = await _context.Book.Include(b=>b.Publisher).ToListAsync();
            }
            switch (sortOrder)
            {
                case " title_desc ":
                    BookD.Books = BookD.Books.OrderByDescending(s =>s.Title);
                    break;
                case " author_desc ":
                    BookD.Books = BookD.Books.OrderByDescending(s =>s.Author.FullName);
                    break;
                case "author":
                    BookD.Books = BookD.Books.OrderBy(s =>s.Author.FullName);
                    break;
                default:
                    BookD.Books = BookD.Books.OrderBy(s => s.Title);
                    break;
            }
    }
}

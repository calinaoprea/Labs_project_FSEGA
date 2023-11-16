using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Calina_Oprea_Lab2.Data;
using Calina_Oprea_Lab2.Models;

namespace Calina_Oprea_Lab2.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly Calina_Oprea_Lab2.Data.Calina_Oprea_Lab2Context _context;

        public IndexModel(Calina_Oprea_Lab2.Data.Calina_Oprea_Lab2Context context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Publisher != null)
            {
                Publisher = await _context.Publisher.ToListAsync();
            }
        }
        public PublisherIndexData PublisherData { get; set; }
        public int PublisherID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            PublisherData = new PublisherIndexData();
            PublisherData.Publishers = await _ context.Publisher
           .Include(i => i.Books)
           .ThenInclude(c => c.Author)
           .OrderBy(i => i.PublisherName)
           .ToListAsync();
            if (id != null)
            {
                PublisherID = id.value _
               Publisher publisher = PublisherData.Publishers
               .Where(i => i.ID == id.Value).Single();
                PublisherData.Books = publisher.books;
            }
    }
}
